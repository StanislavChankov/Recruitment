using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models
{
    public class Department
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Position> Positions { get; set; }
    }
}
