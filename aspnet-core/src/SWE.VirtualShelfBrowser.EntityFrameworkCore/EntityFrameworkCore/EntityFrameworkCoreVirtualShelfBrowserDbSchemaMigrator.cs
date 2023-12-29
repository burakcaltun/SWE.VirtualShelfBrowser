using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SWE.VirtualShelfBrowser.Data;
using Volo.Abp.DependencyInjection;

namespace SWE.VirtualShelfBrowser.EntityFrameworkCore;

public class EntityFrameworkCoreVirtualShelfBrowserDbSchemaMigrator
    : IVirtualShelfBrowserDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreVirtualShelfBrowserDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the VirtualShelfBrowserDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<VirtualShelfBrowserDbContext>()
            .Database
            .MigrateAsync();
    }
}
