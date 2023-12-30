using System;
using Volo.Abp.Application.Dtos;

namespace SWE.VirtualShelfBrowser.Lendings;

public class LendingDto : AuditedEntityDto<Guid>
{
    public Guid UserId { get; set; }
    public string UserName { get; set; }
    public Guid LenderId { get; set; }
    public string LenderName { get; set; }
    public Guid BookId { get; set; }
    public string BookName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

}
