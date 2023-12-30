using System;

using Volo.Abp.Domain.Entities.Auditing;

namespace SWE.VirtualShelfBrowser.Lendings;

public class Lending : FullAuditedAggregateRoot<Guid>
{
    public Guid UserId { get; set; }
    public Guid LenderId { get; set; }
    public Guid BookId { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public Lending()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    public Lending(
        Guid id,
        Guid userId,
        Guid lenderId,
        Guid bookId,
        DateTime startDate,
        DateTime endDate
        )
        : base(id)
    {
        UserId = userId;
        LenderId = lenderId;
        BookId = bookId;
        StartDate = startDate;
        EndDate = endDate;
    }
}
