using System;

namespace Synergy.Recruitment.Data.Models
{
    public class Interview
    {
        public long Id { get; set; }

        public DateTime StartUtcDate { get; set; }

        public long CandidateId { get; set; }

        public long InterviewTypeId { get; set; }

        public virtual Candidate Candidate { get; set; }

        public virtual InterviewType InterviewType { get; set; }
    }
}
