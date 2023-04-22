using CommanderMinApi.Application.Contracts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly CommanderMinApiDbContext _context;

        public GenericRepository(CommanderMinApiDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException(nameof(entity));
            }

            _context.Set<T>().AddAsync(entity);
            _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChangesAsync();
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> All()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>()
                .AsQueryable()
                .Where(predicate).ToListAsync();
        }

        public async Task<T> Get(Guid id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IReadOnlyList<T>> GetPagedReponse(int page, int size)
        {
            return await _context.Set<T>().Skip((page - 1) * size).Take(size).AsNoTracking().ToListAsync();
        }
    }
}
