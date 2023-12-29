using Volo.Abp.Modularity;

namespace SWE.VirtualShelfBrowser;

public abstract class VirtualShelfBrowserApplicationTestBase<TStartupModule> : VirtualShelfBrowserTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
