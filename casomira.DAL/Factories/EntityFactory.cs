using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using casomira.DAL.Interfaces;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace casomira.DAL.Factories
{
    public class EntityFactory : IEntityFactory
    {
        private readonly ChangeTracker _changeTracker;

        internal EntityFactory()
        {
        }

        public EntityFactory(ChangeTracker changeTracker) => _changeTracker = changeTracker;

        public TEntity Create<TEntity>(Guid id) where TEntity : class, IEntity, new()
        {
            TEntity entity = null;
            if (id != Guid.Empty)
            {
                entity = _changeTracker?.Entries<TEntity>().SingleOrDefault(i => i.Entity.Id == id)
                    ?.Entity;
                if (entity != null) return entity;
                entity = new TEntity { Id = id };
                _changeTracker?.Context.Attach(entity);
            }
            else
            {
                entity = new TEntity();
            }
            return entity;
        }
    }
}
