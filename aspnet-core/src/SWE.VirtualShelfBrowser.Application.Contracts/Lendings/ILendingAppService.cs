using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SWE.VirtualShelfBrowser.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SWE.VirtualShelfBrowser.Lendings
{
    public interface ILendingAppService :
    ICrudAppService< //Defines CRUD methods
        LendingDto, //Used to show books
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        CreateUpdateLendingDto> //Used to create/update a book
    {
        // ADD the NEW METHOD
        Task<ListResultDto<BookLookupDto>> GetBookLookupAsync();
    }
}
