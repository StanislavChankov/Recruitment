using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models
{
    public class JobAdvertisement
    {
        public long Id { get; set; }

        public string Description { get; set; }

        public long PositionId { get; set; }

        public virtual Position Position { get; set; }

        public virtual ICollection<CandidateJobAdvertisment> CandidateJobAdvertisments { get; set; }
    }
}
