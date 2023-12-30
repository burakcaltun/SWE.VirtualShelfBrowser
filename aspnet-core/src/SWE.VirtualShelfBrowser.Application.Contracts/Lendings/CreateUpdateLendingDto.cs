using System;
using System.ComponentModel.DataAnnotations;

namespace SWE.VirtualShelfBrowser.Lending;

public class CreateUpdateLendingDto
{


    [Required]
    [DataType(DataType.Date)]
    public DateTime StartDate { get; set; } = DateTime.Now;

    [Required]
    [DataType(DataType.Date)]
    public DateTime EndDate { get; set; } = DateTime.Now;
    public Guid BookId { get; set; }
    public Guid UserId { get; set; }
    public Guid LenderId { get; set; }
}
