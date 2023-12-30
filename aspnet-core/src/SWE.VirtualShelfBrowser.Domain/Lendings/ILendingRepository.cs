using SWE.VirtualShelfBrowser.Books;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace SWE.VirtualShelfBrowser.Lendings
{
    public interface ILendingRepository : IRepository<Lending, Guid>
    {
        Task<Lending> FindByNameAsync(string name);

        Task<List<Lending>> GetListAsync(
            int skipCount,
            int maxResultCount,
            string sorting,
            string filter = null
        );

    }
}
