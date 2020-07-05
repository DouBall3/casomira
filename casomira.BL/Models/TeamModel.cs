using casomira.DAL.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace casomira.BL.Models
{
    public class TeamModel : EntityBaseModel
    {
        public string Origin { get; set; }
        public string Variant { get; set; }
        public Category Category { get; set; }
    }
}
