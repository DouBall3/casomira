using System;
using System.Collections.Generic;
using System.Text;
using casomira.Common.Interfaces;

namespace casomira.BL.Models
{
    public class EntityBaseModel : IId
    {
        public Guid Id { get; set; }
    }
}
