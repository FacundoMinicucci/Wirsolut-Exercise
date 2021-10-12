using Microsoft.EntityFrameworkCore;
using WirsolutExercise.Core.Models;

namespace WirsolutExercise.Infrastucture.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<ClientsModel> Clients { get; set; } = null;
    }
}

