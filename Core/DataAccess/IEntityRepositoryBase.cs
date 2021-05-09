using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess
{
    public class IEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public async Task Add(TEntity Entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(Entity);
                addedEntity.State = EntityState.Added;
                await context.SaveChangesAsync();
            }
        }
        public async Task Delete(TEntity Entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(Entity);
                deletedEntity.State = EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }
        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return await context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }
        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return  filter == null
                    ? await context.Set<TEntity>().ToListAsync()
                    : await context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }
        public async Task Update(TEntity Entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(Entity);
                updatedEntity.State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
    }
}
