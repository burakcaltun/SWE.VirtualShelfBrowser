using System;
using System.Collections.Generic;
using System.Text;
using SWE.VirtualShelfBrowser.Localization;
using Volo.Abp.Application.Services;

namespace SWE.VirtualShelfBrowser;

/* Inherit your application services from this class.
 */
public abstract class VirtualShelfBrowserAppService : ApplicationService
{
    protected VirtualShelfBrowserAppService()
    {
        LocalizationResource = typeof(VirtualShelfBrowserResource);
    }
}
