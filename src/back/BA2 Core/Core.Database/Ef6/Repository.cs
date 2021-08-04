using System;
using System.Collections.Generic;

using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using Core.Data;
using Core.Data.HelperModels;
using Microsoft.EntityFrameworkCore;
using Unity;
using Wave.Data.Repositories;

namespace Wave.Data.Ef6
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected DbSet<TEntity> DbSet => Context?.DbSet<TEntity>();
        protected IQueryable<TEntity> ReadOnlyDbSet => Context?.DbSet<TEntity>().AsNoTracking();

        protected CoreContext Context;

        [InjectionMethod]
        public void Initialize(CoreContext coreContext)
        {
            Context = coreContext;
        }

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="keyValues">
        /// The key values.
        /// </param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public virtual TEntity FindById(int id)
        {
            return DbSet.FirstOrDefault(x => x.EntityState == State.Active && x.Id == id);
        }

        /// <summary>
        /// The find by id and include one property.
        /// </summary>
        /// <param name="id">
        /// The key values.
        /// </param>
        /// <param name="navigationPropertyPath">the navigationPropertyPath</param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        public virtual TEntity FindById<TProperty>(int id, Expression<Func<TEntity, TProperty>> navigationPropertyPath)
        {
            return DbSet.Include(navigationPropertyPath).FirstOrDefault(x => x.EntityState == State.Active && x.Id == id);
        }

        /// <summary>
        /// The select query.
        /// </summary>
        /// <param name="query">
        /// The query.
        /// </param>
        /// <param name="parameters">
        /// The parameters.
        /// </param>
        /// <returns>
        /// The <see cref="IQueryable"/>.
        /// </returns>
        //public virtual IQueryable<TEntity> SelectQuery(string query, params object[] parameters)
        //{
        //    return this.DbSet.SqlQuery(query, parameters).AsQueryable();
        //}

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        public virtual TEntity Insert(TEntity entity)
        {
            return this.DbSet.Add(entity).Entity;
        }

        /// <summary>
        /// The insert range.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        public virtual void InsertRange(IEnumerable<TEntity> entities)
        {
            foreach (var entity in entities)
            {
                this.Insert(entity);
            }
        }

        /// <summary>
        /// The insert graph range.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        public virtual void InsertGraphRange(IEnumerable<TEntity> entities)
        {
            this.DbSet.AddRange(entities);
        }

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>  
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
            ((CoreContext)Context).Entry(entity).State = EntityState.Modified;

            // Loop through each property of Entity type and call same method recursively to set modified state
            Type type = entity.GetType();
            PropertyInfo[] properties = type.GetProperties();

            foreach (PropertyInfo property in properties)
            {
                if (property.PropertyType.BaseType == typeof(Entity))
                {
                    AttachEntity(property.GetValue(entity), maxLevel, level + 1);
                }
            }
        }
        public virtual void Update(TEntity entity)
        {
            AttachEntity(entity);
        }

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        //public virtual void Delete(object id)
        //{
        //    var entity = this.DbSet.Find(id);
        //    this.Delete(entity);
        //}

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        //public virtual void Delete(TEntity entity)
        //{
        //    var convertedEntity = entity as Models.Ef6.Entity;
        //    if (convertedEntity == null)
        //    {
        //        return;
        //    }

        //    var currentEntity = this.DbSet.Find(convertedEntity.Id);
        //    ((WaveContext)this.Context).Entry(currentEntity).State = EntityState.Detached;
        //    this.DbSet.Attach(entity);
        //    ((WaveContext)this.Context).Entry(entity).State = EntityState.Deleted;
        //}
        public virtual void DeleteEntity(TEntity entity)
        {
            ((CoreContext)this.Context).Entry(entity).State = EntityState.Unchanged;
            entity.EntityState = State.Deleted;
        }

        public void SaveChanges()
            => Context.SaveChanges();
    }
}
