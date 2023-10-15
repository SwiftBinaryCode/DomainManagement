using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Domain;
using DomainManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DomainManagement.Persistence.Repositories
{
    public class DomainTypeRepository : GenericRepository<DomainType>, IDomainTypeRepository
    {
        public DomainTypeRepository(DomainDatabaseContext context) : base(context)
        {
        }

        public async Task<bool> IsDomainTypeUnique(string name)
        {
            return await _context.DomainTypes.AnyAsync(q => q.DomainName == name) == false;
        }
    }
}
