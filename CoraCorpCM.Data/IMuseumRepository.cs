using System.Collections.Generic;
using CoraCorpCM.Domain.Models;

namespace CoraCorpCM.Data
{
    public interface IMuseumRepository
    {
        // Create
        int Insert(IEntity entity);

        // Read
        TEntity GetFirstEntity<TEntity>() where TEntity : class, IEntity;
        TEntity GetEntity<TEntity>(int id) where TEntity : class, IEntity;
        IEnumerable<TMuseumEntity> GetEntities<TMuseumEntity>(Museum museum) where TMuseumEntity : class, IMuseumEntity;
        IEnumerable<TEntity> GetEntitiesAsNoTracking<TEntity>() where TEntity : class, IEntity;
        IEnumerable<TMuseumEntity> GetEntitiesAsNoTracking<TMuseumEntity>(Museum museum) where TMuseumEntity : class, IMuseumEntity;
        Museum GetMuseum(IMuseumEntity museumEntity);
        bool EntityExists<TEntity>(int id) where TEntity : class, IEntity;

        // Update
        int Update(IEntity entity);

        // Delete
        int Delete(IEntity entity);
        int Delete<TEntity>(int id) where TEntity : class, IEntity;
    }
}