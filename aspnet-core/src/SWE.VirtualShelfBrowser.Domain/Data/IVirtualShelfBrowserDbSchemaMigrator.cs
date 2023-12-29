using System.Threading.Tasks;

namespace SWE.VirtualShelfBrowser.Data;

public interface IVirtualShelfBrowserDbSchemaMigrator
{
    Task MigrateAsync();
}
