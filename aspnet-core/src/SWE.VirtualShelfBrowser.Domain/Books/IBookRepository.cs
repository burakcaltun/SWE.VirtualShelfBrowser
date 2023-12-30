using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SWE.VirtualShelfBrowser.Books
{
    public interface IBookRepository : IRepository<Book, Guid>
    {
        Task<Book> FindByNameAsync(string name);

        Task<List<Book>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );
    }
}
