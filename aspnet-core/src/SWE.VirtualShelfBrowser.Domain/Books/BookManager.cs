using JetBrains.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Domain.Services;

namespace SWE.VirtualShelfBrowser.Books
{
    public class BookManager : DomainService
    {
        private readonly IBookRepository _bookRepository;

        public BookManager(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Book> CreateAsync(
            [NotNull] string name,
            BookType type,
            [CanBeNull] DateTime publishDate,
            Location physicalLocation,
            string description,
            string coverImage,
            int numberOfPage,
            Guid authorId)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));


            return new Book(
                GuidGenerator.Create(),
                name,
                type,
                publishDate,
                physicalLocation,
                description,
                coverImage,
                numberOfPage,
                authorId
            );
        }

    }
}
