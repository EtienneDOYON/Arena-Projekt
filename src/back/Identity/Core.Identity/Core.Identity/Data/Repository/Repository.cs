using Core.Identity.Data;
using Core.Identity.Models.Enum;
using Core.Identity.Models.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Unity;

namespace Core.Identity.Data
{
    public class Repository<TEntity, TId> : IRepository<TEntity, TId>
        where TEntity : Entity<TId>
    {
        protected ApplicationDbContext Context;
        protected DbSet<TEntity> DbSet => Context?.Set<TEntity>();

        [InjectionMethod]
        public void Initialize(ApplicationDbContext coreContext)
        {
            Context = coreContext;
        }

        public virtual TEntity FindById(TId id)
        {
            return DbSet.FirstOrDefault(x => EqualityComparer<TId>.Default.Equals(x.Id, id) && x.EntityState == Models.Enum.State.Active);
        }

        public virtual TEntity Insert(TEntity entity)
        {
            return this.DbSet.Add(entity).Entity;
        }

        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.Insert(entity);
            }
        }

        public virtual void InsertGraphRange(IEnumerable<TEntity> entities)
        {
            this.DbSet.AddRange(entities);
        }

        private void AttachEntity(object entity, int maxLevel = 2, int level = 1)
        {
            if (level > maxLevel || entity == null)
            {
                // Do not allow to go deeper
                return;
            }

            if (level == 1 && entity is TEntity)
            {
                DbSet.Attach((TEntity)entity);
            }

            // Set entity state as modified
            ((ApplicationDbContext)Context).Entry(entity).State = EntityState.Modified;

            // Loop through each property of Entity type and call same method recursively to set modified state
            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.BaseType == typeof(Entity<TEntity>))
                {
                    AttachEntity(property.GetValue(entity), maxLevel, level + 1);
                }
            }
        }

        public virtual void Update(TEntity entity)
        {
            AttachEntity(entity);
        }

        public virtual void DeleteEntity(TEntity entity)
        {
            ((ApplicationDbContext)this.Context).Entry(entity).State = EntityState.Unchanged;
            entity.EntityState = State.Deleted;
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}
