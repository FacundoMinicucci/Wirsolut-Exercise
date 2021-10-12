using System.Collections.Generic;
using System.Threading.Tasks;

namespace WirsolutExercise.Core.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> GetAll();

        Task<T> GetById(int? id);

        Task Add(T entity);

        Task Update(T entity);

        Task Delete(int id);
    }
}
