using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Authorization;
using SWE.VirtualShelfBrowser.Authors;
using SWE.VirtualShelfBrowser.Books;
using SWE.VirtualShelfBrowser.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace SWE.VirtualShelfBrowser.Lendings
{
    public class LendingAppService :
    CrudAppService<
        Lending, //The Book entity
        LendingDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateLendingDto>, //Used to create/update a book
    ILendingAppService //implement the IBookAppService
    {
        private readonly IBookRepository _bookRepository;

        public LendingAppService(
            IRepository<Lending, Guid> repository,
            IBookRepository bookRepository)
            : base(repository)
        {
            _bookRepository = bookRepository;
        }

        public override async Task<LendingDto> GetAsync(Guid id)
        {

            var queryable = await Repository.GetQueryableAsync();


            var query = from lending in queryable
                        join book in await _bookRepository.GetQueryableAsync() on lending.BookId equals book.Id
                        where book.Id == id
                        select new { lending, book };


            var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
            if (queryResult == null)
            {
                throw new EntityNotFoundException(typeof(Lending), id);
            }

            var lendingDto = ObjectMapper.Map<Lending, LendingDto>(queryResult.lending);
            lendingDto.BookName = queryResult.book.Name;
            return lendingDto;
        }

        public override async Task<PagedResultDto<LendingDto>> GetListAsync(PagedAndSortedResultRequestDto input)
        {

            var queryable = await Repository.GetQueryableAsync();


            var query = from lending in queryable
                        join book in await _bookRepository.GetQueryableAsync() on lening.BookId equals book.Id
                        select new { lending, book };


            query = query
                .OrderBy(NormalizeSorting(input.Sorting))
                .Skip(input.SkipCount)
                .Take(input.MaxResultCount);


            var queryResult = await AsyncExecuter.ToListAsync(query);


            var lendingDtos = queryResult.Select(x =>
            {
                var lendingDto = ObjectMapper.Map<Lending, LendingDto>(x.lending);
                lendingDto.BookName = x.book.Name;
                return lendingDto;
            }).ToList();


            var totalCount = await Repository.GetCountAsync();

            return new PagedResultDto<LendingDto>(
                totalCount,
                lendingDtos
            );
        }

        public async Task<ListResultDto<BookLookupDto>> GetBookLookupAsync()
        {
            var books = await _bookRepository.GetListAsync();

            return new ListResultDto<BookLookupDto>(
                ObjectMapper.Map<List<Book>, List<BookLookupDto>>(books)
            );
        }

        private static string NormalizeSorting(string sorting)
        {
            if (sorting.IsNullOrEmpty())
            {
                return $"lending.{nameof(Lending.StartDate)}";
            }

            if (sorting.Contains("bookName", StringComparison.OrdinalIgnoreCase))
            {
                return sorting.Replace(
                    "bookName",
                    "book.Name",
                    StringComparison.OrdinalIgnoreCase
                );
            }

            return $"lending.{sorting}";
        }
    }

}
