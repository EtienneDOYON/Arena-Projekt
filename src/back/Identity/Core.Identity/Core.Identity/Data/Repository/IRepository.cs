using Core.Identity.Models.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Identity.Data
{
    public interface IRepository<TEntity, TId>
        where TEntity : Entity<TId>
    {
        TEntity FindById(TId id);

        TEntity Insert(TEntity entity);

        void InsertRange(IEnumerable<TEntity> entities);

        void InsertGraphRange(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void DeleteEntity(TEntity entity);

        void SaveChanges();
    }
}
