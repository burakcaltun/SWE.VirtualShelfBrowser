using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace SWE.VirtualShelfBrowser;

[Dependency(ReplaceServices = true)]
public class VirtualShelfBrowserBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "VirtualShelfBrowser";
}
