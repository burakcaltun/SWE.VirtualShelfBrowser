using System;
using Volo.Abp.Application.Dtos;

namespace SWE.VirtualShelfBrowser.Books;

public class AuthorLookupDto : EntityDto<Guid>
{
    public string Name { get; set; }
}
