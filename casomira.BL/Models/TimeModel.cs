using System;
using casomira.Common.Interfaces;
using casomira.DAL.Enums;

namespace casomira.BL.Models
{
    public class TimeModel : EntityBaseModel
    {
        public TimeSpan Time { get; set; }
        public Discipline Discipline { get; set; }
        public TeamModel Team { get; set; }
        public PersonModel Person { get; set; }
    }
}
