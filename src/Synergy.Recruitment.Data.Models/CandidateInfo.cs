using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models
{
    public class CandidateInfo
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public string EmailAddress { get; set; }

        public long CityId { get; set; }

        public virtual City City { get; set; }

        public virtual ICollection<Candidate> Candidates { get; set; }
    }
}
