using System;
using System.Collections.Generic;
using System.Text;
using casomira.DAL.Enums;

namespace casomira.DAL.Entities
{
    public class TimeEntity : EntityBase
    {
        public TimeSpan Time { get; set; }
        public Discipline Discipline { get; set; }
        public TeamEntity Team { get; set; }
        public PersonEntity Person { get; set; }
    }
}
