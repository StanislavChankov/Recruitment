using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models
{
    public class City
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public long CountryId { get; set; }

        public virtual Country Country { get; set; }

        public virtual ICollection<CandidateInfo> CandidateInfos { get; set; }
    }
}
