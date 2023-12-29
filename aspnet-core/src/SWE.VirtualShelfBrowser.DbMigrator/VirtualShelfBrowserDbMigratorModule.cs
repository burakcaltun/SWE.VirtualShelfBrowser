using SWE.VirtualShelfBrowser.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace SWE.VirtualShelfBrowser.DbMigrator;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(VirtualShelfBrowserEntityFrameworkCoreModule),
    typeof(VirtualShelfBrowserApplicationContractsModule)
    )]
public class VirtualShelfBrowserDbMigratorModule : AbpModule
{
}
