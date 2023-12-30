using System;
using System.Collections.Generic;
using System.Text;
using Volo.Abp.Application.Dtos;

namespace SWE.VirtualShelfBrowser.Lendings
{
    public class UserLookupDto : EntityDto<Guid>
    {
        public string Name { get; set; }
    }
}
