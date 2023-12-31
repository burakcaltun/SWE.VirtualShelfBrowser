using Microsoft.AspNetCore.Authorization;
using SWE.VirtualShelfBrowser.Books;
using SWE.VirtualShelfBrowser.Permissions;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Repositories;

namespace SWE.VirtualShelfBrowser.Lendings
{
    public class LendingAppService: VirtualShelfBrowserAppService, ILendingAppService
    {
        private readonly ILendingRepository _lendingRepository;
        private readonly LendingManager _lendingManager;
        private readonly IBookRepository _bookRepository;

        public LendingAppService(
            ILendingRepository lendingRepository,
            LendingManager lendingManager,
            IBookRepository bookRepository)
        {
            _lendingRepository = lendingRepository;
            _lendingManager = lendingManager;
            _bookRepository = bookRepository;
        }
        
        public async Task<LendingDto> GetAsync(Guid id)
        {
            var lending = await _lendingRepository.GetAsync(id);
            return ObjectMapper.Map<Lending, LendingDto>(lending);
        }
        public async Task<PagedResultDto<LendingDto>> GetListAsync(GetLendingListDto input)
        {
            
            var lendings = await _lendingRepository.GetListAsync(
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting,
                input.Filter
            );

            var totalCount = input.Filter == null
                ? await _lendingRepository.CountAsync()
                : await _lendingRepository.CountAsync();

            return new PagedResultDto<LendingDto>(
                totalCount,
                ObjectMapper.Map<List<Lending>, List<LendingDto>>(lendings)
            );
        }

        public async Task<ListResultDto<BookLookupDto>> GetBookLookupAsync()
        {
            var books = await _bookRepository.GetListAsync();

            return new ListResultDto<BookLookupDto>(
                ObjectMapper.Map<List<Book>, List<BookLookupDto>>(books)
            );
        }
        
        //[Authorize(VirtualShelfBrowserPermissions.Lendings.Create)]
        public async Task<LendingDto> CreateAsync(LendingDto input)
        {
            var lending = await _lendingManager.CreateAsync(
                input.UserId,
                input.LenderId,
                input.BookId,
                input.StartDate,
                input.EndDate
            );

            await _lendingRepository.InsertAsync(lending);

            return ObjectMapper.Map<Lending, LendingDto>(lending);
        }

        //[Authorize(VirtualShelfBrowserPermissions.Lendings.Edit)]
        public async Task UpdateAsync(Guid id, LendingDto input)
        {
            var lending = await _lendingRepository.GetAsync(id);

            lending.UserId = input.UserId;
            lending.LenderId = input.LenderId;
            lending.BookId = input.BookId;
            lending.StartDate = input.StartDate;
            lending.EndDate = input.EndDate;

            await _lendingRepository.UpdateAsync(lending);
        }

        //[Authorize(VirtualShelfBrowserPermissions.Lendings.Delete)]
        public async Task DeleteAsync(Guid id)
        {
            await _lendingRepository.DeleteAsync(id);
        }
    }
}
