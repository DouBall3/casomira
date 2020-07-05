using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using casomira.DAL.Enums;

namespace casomira.DAL.Entities
{
    public class TeamEntity : EntityBase
    {
        public string Origin { get; set; }
        public string Variant { get; set; }
        public Category Category { get; set; }
        private sealed class TeamComparer : IEqualityComparer<TeamEntity>
        {
            public bool Equals(TeamEntity x, TeamEntity y)
            {
                if (ReferenceEquals(x, y)) return true;
                if (ReferenceEquals(x, null)) return false;
                if (ReferenceEquals(y, null)) return false;
                if (x.GetType() != y.GetType()) return false;
                return x.Id == y.Id && x.Origin == y.Origin && x.Variant == y.Variant && x.Category == y.Category;
            }

            public int GetHashCode(TeamEntity obj)
            {
                return HashCode.Combine(obj.Id, obj.Origin, obj.Variant, obj.Category);
            }
        }

        public static IEqualityComparer<TeamEntity> TeamEntityComparer { get; } = new TeamComparer();
    }
}
