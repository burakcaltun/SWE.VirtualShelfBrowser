using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SWE.VirtualShelfBrowser.Books
{
    public class BookLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
