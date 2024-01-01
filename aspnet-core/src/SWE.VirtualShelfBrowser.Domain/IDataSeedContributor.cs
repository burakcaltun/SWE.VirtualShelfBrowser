using SWE.VirtualShelfBrowser.Authors;
using SWE.VirtualShelfBrowser.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;

namespace SWE.VirtualShelfBrowser
{
    public class VirtualShelfBrowserSeederContributor:
        IDataSeedContributor, ITransientDependency
    {
        private readonly IRepository<Book, Guid> _bookRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly AuthorManager _authorManager;


        public VirtualShelfBrowserSeederContributor(
        IRepository<Book, Guid> bookRepository,
        IAuthorRepository authorRepository,
        AuthorManager authorManager)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _authorManager = authorManager;
        }


        public async Task SeedAsync(DataSeedContext context)
        {
        }



    }
}
