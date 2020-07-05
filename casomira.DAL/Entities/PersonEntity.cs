using System;
using System.Collections.Generic;
using System.Text;

namespace casomira.DAL.Entities
{
    public class PersonEntity : EntityBase
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public uint Age { get; set; }
        public TeamEntity Team { get; set; }
        private sealed class PersonComparer : IEqualityComparer<PersonEntity>
        {
            public bool Equals(PersonEntity x, PersonEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.FirstName == y.FirstName && x.LastName == y.LastName && x.Age == y.Age && TeamEntity.TeamEntityComparer.Equals(x.Team, y.Team);
            }

            public int GetHashCode(PersonEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.FirstName, obj.LastName, obj.Age);
            }
        }

        public static IEqualityComparer<PersonEntity> PersonEntityComparer { get; } = new PersonComparer();
    }
}
