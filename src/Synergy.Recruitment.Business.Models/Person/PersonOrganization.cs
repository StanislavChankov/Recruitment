using System;

namespace Synergy.Recruitment.Business.Models.Person
{
    public class PersonOrganization
    {
        public long Id { get; set; }

        public long SystemUserId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string EmailAddress { get; set; }

        public long OrganizationId { get; set; }
    }
}
