using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models
{
    public class Position
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public long DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual ICollection<JobAdvertisement> JobAdvertisments { get; set; }
    }
}
