using System;

using Volo.Abp.Domain.Entities.Auditing;

namespace SWE.VirtualShelfBrowser.Books;

public class Lending : AuditedAggregateRoot<Guid>
{
    public Guid UserId { get; set; }
    public Guid LenderId { get; set; }
    public Guid BookId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

}
