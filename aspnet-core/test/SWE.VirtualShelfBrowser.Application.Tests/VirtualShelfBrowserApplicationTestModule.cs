using Volo.Abp.Modularity;

namespace SWE.VirtualShelfBrowser;

[DependsOn(
    typeof(VirtualShelfBrowserApplicationModule),
    typeof(VirtualShelfBrowserDomainTestModule)
)]
public class VirtualShelfBrowserApplicationTestModule : AbpModule
{

}
