using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models
{
    public class Company
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string WebsiteUrl { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public virtual ICollection<CandidateCompany> CandidateCompanies { get; set; }
    }
}
