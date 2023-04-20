using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CommanderMinApi.Application.Contracts.Persistence
{
    public interface IGenericRepository<T, T2> where T : class
    {
        void Add(T entity, T2 id);
        void Update(T entity, T2 id);
        void Delete(T entity);
        Task<T> Get(T2 id);
        Task<IEnumerable<T>> All();
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task<IReadOnlyList<T>> GetPagedReponse(int page, int size);
    }
}
