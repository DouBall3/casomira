using System;
using System.Collections.Generic;
using System.Text;

namespace casomira.BL.Models
{
    public class PersonModel : EntityBaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
        public TeamModel Team { get; set; }
    }
}
