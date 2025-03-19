using Microsoft.EntityFrameworkCore;
using SM.Domaiin.Entities;
using SM.Domaiin.Entities.Base;
using SM.Domaiin.Interfaces;
using SM.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SM.Infra.Repositories.Base
{
    public abstract class BaseRepository<TEntity> : IBaseLocalRepository<TEntity> where TEntity : BaseEntity
    {

        protected readonly AppDbContext _dBContext;

        protected BaseRepository(AppDbContext dbContext)
        {
            _dBContext = dbContext;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            entity.CreatedAt = DateTime.Now;
            await _dBContext.Set<TEntity>().AddAsync(entity);
            await _dBContext.SaveChangesAsync();
            return entity;
        }

        public async Task<TEntity> FindOneId(int id)
        {
            return await _dBContext.Set<TEntity>().FirstOrDefaultAsync(e=> e.Id == id);
        }

        public async Task<TEntity> FindOneAsyncPredicate(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dBContext.Set<TEntity>().FirstOrDefaultAsync(predicate);
        }

        public async Task<List<TEntity>> GetAll()
        {
            return await _dBContext.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> deleteAsync(TEntity entity)
        {
            entity.DeletedAt = DateTime.Now;
            entity.IsDeleted = true;
            _dBContext.Set<TEntity>().Update(entity);
            await _dBContext.SaveChangesAsync();
            return entity;
        }
    }
}
