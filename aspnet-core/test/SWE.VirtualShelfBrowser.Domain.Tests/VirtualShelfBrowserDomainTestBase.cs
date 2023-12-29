using Volo.Abp.Modularity;

namespace SWE.VirtualShelfBrowser;

/* Inherit from this class for your domain layer tests. */
public abstract class VirtualShelfBrowserDomainTestBase<TStartupModule> : VirtualShelfBrowserTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
