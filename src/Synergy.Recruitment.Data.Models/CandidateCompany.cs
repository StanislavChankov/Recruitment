using System;

namespace Synergy.Recruitment.Data.Models
{
    public class CandidateCompany
    {
        public long Id { get; set; }

        public long CandidateId { get; set; }

        public long CompanyId { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual Company Company { get; set; }
    }
}
