using System;
using System.Collections.Generic;
using System.Text;
using SWE.VirtualShelfBrowser.Books;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace SWE.VirtualShelfBrowser.Lending
{
    public interface ILendingAppService : 
        ICrudAppService<
        LendingDto,
        Guid, //Primary key of the book entity
        PagedAndSortedResultRequestDto, //Used for paging/sorting
        Books.CreateUpdateBookDto> //Used to create/update a book>
    {
    }
}
