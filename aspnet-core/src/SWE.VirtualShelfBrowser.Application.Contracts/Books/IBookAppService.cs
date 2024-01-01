using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SWE.VirtualShelfBrowser.Books;

public interface IBookAppService :
ICrudAppService< //Defines CRUD methods
        BookDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateBookDto> //Used to create/update a book
{
    // ADD the NEW METHOD
    Task<ListResultDto<AuthorLookupDto>> GetAuthorLookupAsync();
}
