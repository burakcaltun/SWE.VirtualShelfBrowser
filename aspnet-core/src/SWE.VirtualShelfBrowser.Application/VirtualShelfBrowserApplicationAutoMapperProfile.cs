using AutoMapper;
using SWE.VirtualShelfBrowser.Authors;
using SWE.VirtualShelfBrowser.Books;

namespace SWE.VirtualShelfBrowser;

public class VirtualShelfBrowserApplicationAutoMapperProfile : Profile
{
    public VirtualShelfBrowserApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();
    }
}
