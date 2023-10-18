using DomainManagement.Application.Contracts.Persistence;
using DomainManagement.Domain.Common;
using DomainManagement.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace DomainManagement.Persistence.Repositories
{
    // The GenericRepository class provides a generic implementation for a repository that can be used with any entity type that extends BaseEntity.
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        // Protected field holding the database context, allowing derived classes and this base class to have access to it.
        protected readonly DomainDatabaseContext _context;

        // Constructor that initializes the database context. It's public so derived classes can also call this constructor.
        public GenericRepository(DomainDatabaseContext context)
        {
            this._context = context;
        }

        // Asynchronous method that adds the provided entity to the database context and saves the changes.
        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        // Asynchronous method that removes the provided entity from the database context and saves the changes.
        public async Task DeleteAsync(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        // Asynchronous method that retrieves all entities of type T from the database as a list.
        public async Task<IReadOnlyList<T>> GetAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        // Asynchronous method that retrieves an entity of type T with the specified ID from the database.
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().AsNoTracking().FirstOrDefaultAsync(q => q.Id == id);
        }

        // Asynchronous method that updates the provided entity in the database context and saves the changes.
        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
