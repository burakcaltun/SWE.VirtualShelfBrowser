using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace SWE.VirtualShelfBrowser.Data;

/* This is used if database provider does't define
 * IVirtualShelfBrowserDbSchemaMigrator implementation.
 */
public class NullVirtualShelfBrowserDbSchemaMigrator : IVirtualShelfBrowserDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync()
    {
        return Task.CompletedTask;
    }
}
