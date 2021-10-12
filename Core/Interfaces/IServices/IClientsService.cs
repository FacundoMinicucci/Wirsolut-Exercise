using System.Collections.Generic;
using System.Threading.Tasks;
using WirsolutExercise.Core.DTOs;

namespace WirsolutExercise.Core.Interfaces.IServices
{
    public interface IClientsService
    {
        Task<IEnumerable<ClientsDTO>> GetAll();

        Task<IEnumerable<ClientsDTO>> GetAll(string searchString);

        Task<ClientsDTO> GetById(int? id);

        Task Add(ClientsAddDTO client);

        Task Update(ClientsUpdateDTO clientsDTO);

        Task Delete(int id);
    }
}