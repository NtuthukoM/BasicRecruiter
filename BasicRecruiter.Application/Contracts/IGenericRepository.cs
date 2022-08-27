using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicRecruiter.Application.Contracts
{
    public interface IGenericRepository<T>
        where T : class
    {
        Task<T> GetByIdAsync(int? id);
        Task<List<T>> GetAllAsync();
        Task<bool> Exists(int id);

        Task<bool> DeleteAsync(int id);
        Task<bool> UpdateAsync(T entity);
        Task<T> AddAsync(T entity);

    }
}
