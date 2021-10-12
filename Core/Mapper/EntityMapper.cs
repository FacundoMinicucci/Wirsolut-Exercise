using WirsolutExercise.Core.DTOs;
using WirsolutExercise.Core.Models;

namespace WirsolutExercise.Core.Mapper
{
    public class EntityMapper
    {
        public ClientsDTO FromClientsModelToClientsDTO(ClientsModel clientModel)
        {
            var clientsDTO = new ClientsDTO()
            {
                Id = clientModel.Id,
                FirstName = clientModel.FirstName,
                LastName = clientModel.LastName,
                DNI = clientModel.DNI,
                CUIT = clientModel.CUIT,
                Address = clientModel.Address,
                Location = clientModel.Location
            };

            return clientsDTO;
        }

        public ClientsModel FromClientsDTOToClientsModel(ClientsDTO clientsDTO)
        {
            var clientModel = new ClientsModel()
            {
                FirstName = clientsDTO.FirstName,
                LastName = clientsDTO.LastName,
                DNI = clientsDTO.DNI,
                CUIT = clientsDTO.CUIT,
                Address = clientsDTO.Address,
                Location = clientsDTO.Location
            };

            return clientModel;
        }

        public ClientsModel FromClientsAddDTOToClientsModel(ClientsAddDTO clientsDTO)
        {
            var clientModel = new ClientsModel()
            {
                FirstName = clientsDTO.FirstName,
                LastName = clientsDTO.LastName,
                DNI = clientsDTO.DNI,
                CUIT = clientsDTO.CUIT,
                Address = clientsDTO.Address,
                Location = clientsDTO.Location
            };

            return clientModel;
        }

        public ClientsUpdateDTO FromClientsModelToClientsUpdateDTO(ClientsModel clientsModel, ClientsUpdateDTO clientsDTO)
        {
            clientsDTO.FirstName = clientsModel.FirstName;
            clientsDTO.LastName = clientsModel.LastName;
            clientsDTO.DNI = clientsModel.DNI;
            clientsDTO.CUIT = clientsModel.CUIT;
            clientsDTO.Address = clientsModel.Address;
            clientsDTO.Location = clientsModel.Location;

            return clientsDTO;
        }

        public ClientsModel FromClientsUpdateDTOToClientsModel(ClientsUpdateDTO clientsDTO, ClientsModel clientsModel)
        {
            clientsModel.FirstName = clientsDTO.FirstName;
            clientsModel.LastName = clientsDTO.LastName;
            clientsModel.DNI = clientsDTO.DNI;
            clientsModel.CUIT = clientsDTO.CUIT;
            clientsModel.Address = clientsDTO.Address;
            clientsModel.Location = clientsDTO.Location;

            return clientsModel;
        }
    }
}

