using CommanderMinApi.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Persistence.Repositories
{
    public class GenericRepository<T, T2> : IGenericRepository<T, T2> where T : class
    {
        public void Add(T entity, T2 id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> All()
        {
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<T> Get(T2 id)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<T>> GetPagedReponse(int page, int size)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity, T2 id)
        {
            throw new NotImplementedException();
        }
    }
}
