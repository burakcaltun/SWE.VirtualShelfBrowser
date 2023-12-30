using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SWE.VirtualShelfBrowser.Lendings
{
    public class GetLendingListDto : PagedAndSortedResultRequestDto
    {
        public string? Filter { get; set; }
    }
}
