using HRManagement.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HRManagement.Application.Persistence.Cortract
{
    public interface IGenericRepository<T> where T : BaseDomainEntity
    {
        Task<T> GetById(int id);

        Task<bool> IsExist(int id);

        Task<IReadOnlyList<T>> GetAll();

        Task<T> Add(T entity);

        Task<T> Update(T entity);

        Task<T> Delete(T entity);



    }
}
