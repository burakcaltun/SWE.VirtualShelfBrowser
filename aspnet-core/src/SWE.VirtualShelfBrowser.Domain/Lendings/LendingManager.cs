using SWE.VirtualShelfBrowser.Books;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace SWE.VirtualShelfBrowser.Lendings
{
    public class LendingManager: DomainService
    {
        private readonly ILendingRepository _lendingRepository;

        public LendingManager(ILendingRepository lendingRepository)
        {
            _lendingRepository = lendingRepository;
        }

        public async Task<Lending> CreateAsync(
            Guid userId,
            Guid lenderId,
            Guid bookId,
            DateTime startDate,
            DateTime endDate
            )
        {


            return new Lending(
                GuidGenerator.Create(),
                userId,
                lenderId,
                bookId,
                startDate,
                endDate
            );
        }
    }
}
