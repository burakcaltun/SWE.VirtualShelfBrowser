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
        CreateMap<Book, BookLookupDto>();

        CreateMap<Author, AuthorDto>();
        CreateMap<Author, AuthorLookupDto>();

        CreateMap<Lending, LendingDto>();
        CreateMap<CreateUpdateLendingDto, Lending>();
    }
}
