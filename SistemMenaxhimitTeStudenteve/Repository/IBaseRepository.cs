using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SistemMenaxhimitTeStudenteve.Repository
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> GetAsync(int? id);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task RemoveAsync(int id);
        Task SaveChangesAsync();
    }
}
