using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading.Tasks;
using SWE.VirtualShelfBrowser.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
namespace SWE.VirtualShelfBrowser.Books
{
    public class EfCoreBookRepository : EfCoreRepository<VirtualShelfBrowserDbContext, Book, Guid>,
        IBookRepository
    {
        public EfCoreBookRepository(
            IDbContextProvider<VirtualShelfBrowserDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<Book> FindByNameAsync(string name)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet.FirstOrDefaultAsync(book => book.Name == name);
        }

        public async Task<List<Book>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null)
        {
            var dbSet = await GetDbSetAsync();
            return await dbSet
                .WhereIf(
                    !filter.IsNullOrWhiteSpace(),
                    author => author.Name.Contains(filter)
                    )
                .OrderBy(sorting)
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync();
        }
    }
}
