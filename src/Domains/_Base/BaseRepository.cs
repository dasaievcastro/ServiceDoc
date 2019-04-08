using System.Collections.Generic;
using System.Linq;
using Domain.Context;

namespace Domain._Base
{
   public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Entity
    {
        protected readonly ApplicationDbContext Context;

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public void Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public virtual TEntity SearchForId(int id)
        {
            var query = Context.Set<TEntity>().Where(entidade => entidade.Id == id);
            return query.Any() ? query.First() : null;
        }

        public virtual List<TEntity> Search()
        {
            var entidades = Context.Set<TEntity>().ToList();
            return entidades.Any() ? entidades : new List<TEntity>();
        }
    }
}
