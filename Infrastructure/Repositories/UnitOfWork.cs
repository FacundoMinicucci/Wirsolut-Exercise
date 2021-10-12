using System.Threading.Tasks;
using WirsolutExercise.Core.Interfaces;
using WirsolutExercise.Core.Models;
using WirsolutExercise.Infrastructure.Repositories;
using WirsolutExercise.Infrastucture.Data;

namespace WirsolutExercise.Infrastucture.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IClientsRepository _clientsRepository;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public IClientsRepository ClientsRepository => _clientsRepository ??= new ClientsRepository(_context);

        public void Dispose()
        {
            if (_context != null) _context.Dispose();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
