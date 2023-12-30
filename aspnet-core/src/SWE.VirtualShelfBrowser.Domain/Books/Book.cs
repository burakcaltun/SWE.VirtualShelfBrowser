using JetBrains.Annotations;
using System;

using Volo.Abp.Domain.Entities.Auditing;

namespace SWE.VirtualShelfBrowser.Books;

public class Book : FullAuditedAggregateRoot<Guid>
{
    //Title(mandatory)
    //Category(mandatory)
    //Author(mandatory)
    //Publication Date(mandatory)
    //Physical Location(mandatory)
    //Description
    //Cover image
    //Number of pages
    public string Name { get; set; }

    public BookType Type { get; set; }

    public DateTime PublishDate { get; set; }
    public Location PhysicalLocation { get; set; }
    public string Description { get; set; }
    public string CoverImage { get; set; }
    public int NumberOfPage { get; set; }
    public Guid AuthorId { get; set; }

    private Book()
    {
        /* This constructor is for deserialization / ORM purpose */
    }

    public Book(
        Guid id,
        [NotNull] string name,
        BookType type,
        [CanBeNull] DateTime publishDate,
        Location physicalLocation,
        string description,
        string coverImage,
        int numberOfPage,
        Guid authorId)
        : base(id)
    {
        Name = name;
        Type = type;
        PublishDate = publishDate;
        PhysicalLocation = physicalLocation;
        Description = description;
        CoverImage = coverImage;
        NumberOfPage = numberOfPage;
        AuthorId = authorId;
    }

}
