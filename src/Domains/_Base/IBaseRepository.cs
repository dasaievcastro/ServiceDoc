using System;
using System.Collections.Generic;

namespace Domain._Base
{
    public interface IBaseRepository<TEntity>
    {
        TEntity SearchForId(int id);
        List<TEntity> Search();
        void Add(TEntity entity);
    }
}
