using Volo.Abp.Application.Dtos;

namespace SWE.VirtualShelfBrowser.Books;

public class GetBookListDto : PagedAndSortedResultRequestDto
{
    public string? Filter { get; set; }
}
