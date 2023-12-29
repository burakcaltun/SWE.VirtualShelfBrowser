using Volo.Abp.Modularity;

namespace SWE.VirtualShelfBrowser;

[DependsOn(
    typeof(VirtualShelfBrowserDomainModule),
    typeof(VirtualShelfBrowserTestBaseModule)
)]
public class VirtualShelfBrowserDomainTestModule : AbpModule
{

}
