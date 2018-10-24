using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models
{
    public class Process
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<OrganizationProcess> OrganizationProcesses { get; set; }
    }
}
