using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WirsolutExercise.Core.Interfaces;
using WirsolutExercise.Core.Models;
using WirsolutExercise.Infrastucture.Data;

namespace WirsolutExercise.Infrastucture.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : EntityBase
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _entities;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();

        }

        public async Task Add(T entity)
        {
            entity.CreatedAt = DateTime.Now;

            entity.IsDeleted = false;

            await _entities.AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await _entities.FindAsync(id);

            entity.IsDeleted = true;

            entity.CreatedAt = DateTime.Now;

            _entities.Update(entity);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            var list = await _entities.ToListAsync().ContinueWith(x => x.Result.FindAll(e => e.IsDeleted == false));

            return list;
        }

        public async Task<T> GetById(int? id)
        {
            var entity = await _entities.FirstOrDefaultAsync(x => x.Id == id && x.IsDeleted == false);

            return entity;
        }

        public async Task Update(T entity)
        {
            entity.CreatedAt = DateTime.Now;

            _entities.Update(entity);
        }
    }
}

