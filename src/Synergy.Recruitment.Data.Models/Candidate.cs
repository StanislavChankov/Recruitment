using System;
using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models
{
    public class Candidate
    {
        public long Id { get; set; }
        
        public long CandidateInfoId { get; set; }

        public bool IsCurrent { get; set; }

        public DateTime UpdatedOn { get; set; }

        public virtual CandidateInfo CandidateInfo { get; set; }
        
        public virtual ICollection<Interview> Interviews { get; set; }

        public virtual ICollection<CandidateCompany> CandidateCompanies { get; set; }

        public virtual ICollection<CandidateJobAdvertisment> CandidateJobAdvertisments { get; set; }
    }
}
