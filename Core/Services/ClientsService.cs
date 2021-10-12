using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirsolutExercise.Core.DTOs;
using WirsolutExercise.Core.Interfaces;
using WirsolutExercise.Core.Interfaces.IServices;
using WirsolutExercise.Core.Mapper;

namespace WirsolutExercise.Core.Services
{
    public class ClientsService : IClientsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ClientsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task Add(ClientsAddDTO newClient)
        {
            try
            {
                var mapper = new EntityMapper();

                var client = mapper.FromClientsAddDTOToClientsModel(newClient);

                await _unitOfWork.ClientsRepository.Add(client);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                await _unitOfWork.ClientsRepository.Delete(id);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public async Task Update(ClientsUpdateDTO clientsDTO)
        {
            try
            {
                var mapper = new EntityMapper();

                var client = await _unitOfWork.ClientsRepository.GetById(clientsDTO.Id);

                var newClient = mapper.FromClientsUpdateDTOToClientsModel(clientsDTO, client);

                await _unitOfWork.ClientsRepository.Update(newClient);

                await _unitOfWork.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ClientsDTO>> GetAll()
        {
            try
            {
                var clients = await _unitOfWork.ClientsRepository.GetAll();

                var clientsDTO = new List<ClientsDTO>();

                if (clients.Any())
                {
                    var mapper = new EntityMapper();                    

                    foreach (var client in clients)
                    {
                        var clientDTO = mapper.FromClientsModelToClientsDTO(client);

                        clientsDTO.Add(clientDTO);
                    }
                }

                 return clientsDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<IEnumerable<ClientsDTO>> GetAll(string searchString)
        {
            try
            {
                var clients = await _unitOfWork.ClientsRepository.GetAll(searchString);

                var clientsDTO = new List<ClientsDTO>();

                if (clients.Any())
                {
                    var mapper = new EntityMapper();

                    foreach (var client in clients)
                    {
                        var clientDTO = mapper.FromClientsModelToClientsDTO(client);

                        clientsDTO.Add(clientDTO);
                    }
                }

                return clientsDTO;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<ClientsDTO> GetById(int? id)
        {
            try
            {
                var client = await _unitOfWork.ClientsRepository.GetById(id);

                if (client == null) return null;

                var mapper = new EntityMapper();

                return mapper.FromClientsModelToClientsDTO(client);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

    }
}

