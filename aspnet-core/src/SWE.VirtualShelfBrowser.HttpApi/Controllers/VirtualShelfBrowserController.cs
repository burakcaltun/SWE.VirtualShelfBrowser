using SWE.VirtualShelfBrowser.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace SWE.VirtualShelfBrowser.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class VirtualShelfBrowserController : AbpControllerBase
{
    protected VirtualShelfBrowserController()
    {
        LocalizationResource = typeof(VirtualShelfBrowserResource);
    }
}
