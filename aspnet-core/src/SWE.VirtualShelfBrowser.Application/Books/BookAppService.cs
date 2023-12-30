using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SWE.VirtualShelfBrowser.Authors;
using SWE.VirtualShelfBrowser.Permissions;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Repositories;

namespace SWE.VirtualShelfBrowser.Books;

[Authorize(VirtualShelfBrowserPermissions.Books.Default)]
public class BookAppService :
    //CrudAppService<
    //    Book, //The Book entity
    //    BookDto, //Used to show books
    //    Guid, //Primary key of the book entity
    //    PagedAndSortedResultRequestDto, //Used for paging/sorting
    //    CreateUpdateBookDto>, //Used to create/update a book
    VirtualShelfBrowserAppService,
    IBookAppService //implement the IBookAppService
{
    private readonly IBookRepository _bookRepository;
    private readonly BookManager _bookManager;
    private readonly IAuthorRepository _authorRepository;

    public BookAppService(
        IBookRepository bookRepository,
        BookManager bookManager,
        IAuthorRepository authorRepository)
    {
        _bookRepository = bookRepository;
        _bookManager = bookManager;
        _authorRepository = authorRepository;
    }
    //public BookAppService(IRepository<Book, Guid> repository, IBookRepository authorRepository)
    //    : base(repository)
    //{
    //    _authorRepository = authorRepository;
    //    GetPolicyName = VirtualShelfBrowserPermissions.Books.Default;
    //    GetListPolicyName = VirtualShelfBrowserPermissions.Books.Default;
    //    CreatePolicyName = VirtualShelfBrowserPermissions.Books.Create;
    //    UpdatePolicyName = VirtualShelfBrowserPermissions.Books.Edit;
    //    DeletePolicyName = VirtualShelfBrowserPermissions.Books.Delete;
    //}

    //public override async Task<BookDto> GetAsync(Guid id)
    //{
    //    //Get the IQueryable<Book> from the repository
    //    var queryable = await Repository.GetQueryableAsync();

    //    //Prepare a query to join books and authors
    //    var query = from book in queryable
    //                join author in await _authorRepository.GetQueryableAsync() on book.AuthorId equals author.Id
    //                where book.Id == id
    //                select new { book, author };

    //    //Execute the query and get the book with author
    //    var queryResult = await AsyncExecuter.FirstOrDefaultAsync(query);
    //    if (queryResult == null)
    //    {
    //        throw new EntityNotFoundException(typeof(Book), id);
    //    }

    //    var bookDto = ObjectMapper.Map<Book, BookDto>(queryResult.book);
    //    bookDto.AuthorName = queryResult.author.Name;
    //    return bookDto;
    //}

    //public override async Task<PagedResultDto<BookDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    //{
    //    //Get the IQueryable<Book> from the repository
    //    var queryable = await Repository.GetQueryableAsync();

    //    //Prepare a query to join books and authors
    //    var query = from book in queryable
    //                join author in await _authorRepository.GetQueryableAsync() on book.AuthorId equals author.Id
    //                select new { book, author };

    //    //Paging
    //    query = query
    //        .OrderBy(NormalizeSorting(input.Sorting))
    //        .Skip(input.SkipCount)
    //        .Take(input.MaxResultCount);

    //    //Execute the query and get a list
    //    var queryResult = await AsyncExecuter.ToListAsync(query);

    //    //Convert the query result to a list of BookDto objects
    //    var bookDtos = queryResult.Select(x =>
    //    {
    //        var bookDto = ObjectMapper.Map<Book, BookDto>(x.book);
    //        bookDto.AuthorName = x.author.Name;
    //        return bookDto;
    //    }).ToList();

    //    //Get the total count with another query
    //    var totalCount = await Repository.GetCountAsync();

    //    return new PagedResultDto<BookDto>(
    //        totalCount,
    //        bookDtos
    //    );
    //}
    public async Task<BookDto> GetAsync(Guid id)
    {
        var book = await _bookRepository.GetAsync(id);
        return ObjectMapper.Map<Book, BookDto>(book);
    }
    public async Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input)
    {
        if (input.Sorting.IsNullOrWhiteSpace())
        {
            input.Sorting = nameof(Book.Name);
        }

        var books = await _bookRepository.GetListAsync(
            input.SkipCount,
            input.MaxResultCount,
            input.Sorting,
            input.Filter
        );

        var totalCount = input.Filter == null
            ? await _bookRepository.CountAsync()
            : await _bookRepository.CountAsync(
                book => book.Name.Contains(input.Filter));

        return new PagedResultDto<BookDto>(
            totalCount,
            ObjectMapper.Map<List<Book>, List<BookDto>>(books)
        );
    }

    public async Task<ListResultDto<BookLookupDto>> GetAuthorLookupAsync()
    {
        var authors = await _authorRepository.GetListAsync();

        return new ListResultDto<BookLookupDto>(
            ObjectMapper.Map<List<Author>, List<BookLookupDto>>(authors)
        );
    }

    //private static string NormalizeSorting(string sorting)
    //{
    //    if (sorting.IsNullOrEmpty())
    //    {
    //        return $"book.{nameof(Book.Name)}";
    //    }

    //    if (sorting.Contains("authorName", StringComparison.OrdinalIgnoreCase))
    //    {
    //        return sorting.Replace(
    //            "authorName",
    //            "author.Name",
    //            StringComparison.OrdinalIgnoreCase
    //        );
    //    }

    //    return $"book.{sorting}";
    //}
    [Authorize(VirtualShelfBrowserPermissions.Books.Create)]
    public async Task<BookDto> CreateAsync(BookDto input)
    {
        var book = await _bookManager.CreateAsync(
            input.Name,
            input.Type,
            input.PublishDate,
            input.PhysicalLocation,
            input.Description,
            input.CoverImage,
            input.NumberOfPage,
            input.AuthorId
        );

        await _bookRepository.InsertAsync(book);

        return ObjectMapper.Map<Book, BookDto>(book);
    }

    [Authorize(VirtualShelfBrowserPermissions.Books.Edit)]
    public async Task UpdateAsync(Guid id, BookDto input)
    {
        var book = await _bookRepository.GetAsync(id);

        book.Name = input.Name;
        book.Type = input.Type;
        book.PublishDate = input.PublishDate;
        book.PhysicalLocation = input.PhysicalLocation;
        book.Description = input.Description;
        book.CoverImage = input.CoverImage;
        book.NumberOfPage = input.NumberOfPage;
        book.AuthorId = input.AuthorId;

        await _bookRepository.UpdateAsync(book);
    }

    [Authorize(VirtualShelfBrowserPermissions.Books.Delete)]
    public async Task DeleteAsync(Guid id)
    {
        await _bookRepository.DeleteAsync(id);
    }
}
