using System.Collections.Generic;
using System.Threading.Tasks;
using WirsolutExercise.Core.Models;

namespace WirsolutExercise.Core.Interfaces
{
    public interface IClientsRepository : IBaseRepository<ClientsModel>
    {
        Task<IEnumerable<ClientsModel>> GetAll(string searchString);
    }
}
