using Core.Data;
using Core.Data.HelperModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Wave.Data.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity FindById(int id);

        /// <summary>
        /// The find.
        /// </summary>
        /// <param name="id">ID</param>
        /// <param name="include">The property to include</param>
        /// <returns>
        /// The <see cref="TEntity"/>.
        /// </returns>
        TEntity FindById<TProperty>(int id, Expression<Func<TEntity, TProperty>> include);

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
        //IQueryable<TEntity> SelectQuery(string query, params object[] parameters);

        /// <summary>
        /// The insert.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        TEntity Insert(TEntity entity);

        /// <summary>
        /// The insert range.
        /// </summary>
        /// <param name="entities">
        /// The entities.
        /// </param>
        void InsertRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// The update.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        void Update(TEntity entity);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="id">
        /// The id.
        /// </param>
        //void Delete(object id);

        /// <summary>
        /// The delete.
        /// </summary>
        /// <param name="entity">
        /// The entity.
        /// </param>
        //void Delete(TEntity entity);

        void DeleteEntity(TEntity entity);

        void SaveChanges();
    }
}