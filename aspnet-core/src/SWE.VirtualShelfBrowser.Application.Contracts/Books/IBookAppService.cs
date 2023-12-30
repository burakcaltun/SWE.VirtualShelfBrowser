using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SWE.VirtualShelfBrowser.Books;

public interface IBookAppService : IApplicationService
//ICrudAppService< //Defines CRUD methods
//    BookDto, //Used to show books
//    Guid, //Primary key of the book entity
//    PagedAndSortedResultRequestDto, //Used for paging/sorting
//    CreateUpdateBookDto> //Used to create/update a book
{
    // ADD the NEW METHOD
    Task<BookDto> GetAsync(Guid id);
    Task<PagedResultDto<BookDto>> GetListAsync(GetBookListDto input);
    Task<BookDto> CreateAsync(BookDto input);
    Task UpdateAsync(Guid id, BookDto input);
    Task DeleteAsync(Guid id);
    Task<ListResultDto<BookLookupDto>> GetAuthorLookupAsync();
}
