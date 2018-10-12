using System;

namespace Synergy.Recruitment.Data.Models
{
    public class Candidate
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int PositionId { get; set; }

        public DateTime UpdatedOn { get; set; }
    }
}
