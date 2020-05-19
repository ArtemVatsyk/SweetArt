using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SweetArt
{
    public interface IAsyncRepository<T> where T : class
    {
        Task Add(T entity);
        Task Update(T entity);
        Task Remove(T entity);

        Task<IEnumerable<T>> GetAll();
    }
}
