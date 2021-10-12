using System;
using System.Threading.Tasks;
using WirsolutExercise.Core.Models;

namespace WirsolutExercise.Core.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IClientsRepository ClientsRepository { get; }

        Task SaveChangesAsync();

        void SaveChanges();
    }
}
