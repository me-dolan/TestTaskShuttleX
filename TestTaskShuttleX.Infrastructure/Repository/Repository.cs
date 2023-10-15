using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestTaskShuttleX.Infrastructure.Interface;

namespace TestTaskShuttleX.Infrastructure.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private ApplicationDbContext _context;
        internal DbSet<TEntity> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public void Create(TEntity entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public async Task CreateAsync(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public void Delete(TEntity entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }

        virtual public TEntity FindById(int id)
        {
            var entrie = _dbSet.Find(id);

            return entrie;
        }

        virtual public async Task<TEntity> FindByIdASync(int id)
        {
            var entrie = await _dbSet.FindAsync(id);

            return entrie;
        }

        virtual public IEnumerable<TEntity> GetAll()
        {
            var entrie = _dbSet.AsEnumerable();

            return entrie;
        }
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            var entrie = _dbSet.ToListAsync();

            return await entrie;
        }
        public void Update(TEntity entity)
        {
            _dbSet.Update(entity);
            _context.SaveChanges();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public async void SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

    }
}
