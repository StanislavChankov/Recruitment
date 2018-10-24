using System;
using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class Person
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public string EmailAddress { get; set; }

        public bool IsActive { get; set; }

        public ICollection<SystemUser> SystemUsers { get; set; }
    }
}
