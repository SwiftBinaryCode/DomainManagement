using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Domain;
using DomainManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DomainManagement.Persistence.Repositories
{
    // This class represents the repository for accessing and managing DomainType entities in the database. 
    // It extends the GenericRepository and implements IDomainTypeRepository interface for DomainType-specific queries.
    public class DomainTypeRepository : GenericRepository<DomainType>, IDomainTypeRepository
    {
        // The constructor initializes the base GenericRepository with the provided database context.
        public DomainTypeRepository(DomainDatabaseContext context) : base(context)
        {
        }

        // This asynchronous method checks if a DomainType with a given name exists in the database.
        // It returns true if the domain type name is unique (not present in the database), otherwise returns false.
        public async Task<bool> IsDomainTypeUnique(string name)
        {
            // Using AnyAsync to determine if any matching domain type exists with the provided name.
            // If none exists, the domain name is unique, and the method returns true.
            return await _context.DomainTypes.AnyAsync(q => q.DomainName == name) == false;
        }
    }
}
