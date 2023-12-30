using System;
using System.ComponentModel.DataAnnotations;

namespace SWE.VirtualShelfBrowser.Books;

public class CreateUpdateBookDto
{
    [Required]
    [StringLength(128)]
    public string Name { get; set; }

    [Required]
    public BookType Type { get; set; } = BookType.Undefined;

    [Required]
    [DataType(DataType.Date)]
    public DateTime PublishDate { get; set; } = DateTime.Now;
    public Location PhysicalLocation { get; set; } = Location.A1;

    [Required]
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public int NumberOfPage { get; set; }

    public Guid AuthorId { get; set; }
}
