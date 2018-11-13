using System;
using Synergy.Recruitment.Data.Models.Abstract;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class Person : BaseEntity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime? BirthDate { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }
        //public long SystemUserId { get; set; }
        public SystemUser SystemUser { get; set; }
    }
}
