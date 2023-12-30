using AutoMapper;
using SWE.VirtualShelfBrowser.Authors;
using SWE.VirtualShelfBrowser.Books;
using SWE.VirtualShelfBrowser.Lendings;

namespace SWE.VirtualShelfBrowser;

public class VirtualShelfBrowserApplicationAutoMapperProfile : Profile
{
    public VirtualShelfBrowserApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
        CreateMap<Author, AuthorDto>();
        CreateMap<Author, BookLookupDto>();
        CreateMap<Lending, LendingDto>();
        CreateMap<LendingDto, Lending>();
    }
}
