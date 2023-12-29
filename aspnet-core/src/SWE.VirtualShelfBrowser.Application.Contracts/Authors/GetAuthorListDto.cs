using Volo.Abp.Application.Dtos;

namespace SWE.VirtualShelfBrowser.Authors;

public class GetAuthorListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
