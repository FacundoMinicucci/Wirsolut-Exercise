using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WirsolutExercise.Core.Interfaces;
using WirsolutExercise.Core.Models;
using WirsolutExercise.Infrastucture.Data;
using WirsolutExercise.Infrastucture.Repositories;

namespace WirsolutExercise.Infrastructure.Repositories
{
    public class ClientsRepository : BaseRepository<ClientsModel>, IClientsRepository
    {
        private readonly ApplicationDbContext _context;

        public ClientsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
             
        public async Task<IEnumerable<ClientsModel>> GetAll(string searchString)
        {
            var clientsList = await _context.Clients
                .Where(x => x.FirstName.Contains(searchString) || x.LastName.Contains(searchString))
                .ToListAsync().ContinueWith(x => x.Result.FindAll(e => e.IsDeleted == false));

            return clientsList;
        }
    }
}
