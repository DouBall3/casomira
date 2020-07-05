using System;
using System.Collections.Generic;
using System.Text;
using casomira.DAL.Interfaces;

namespace casomira.DAL.Entities
{
    public class EntityBase : IEntity
    {
        public Guid Id { get; set; }
    }
}
