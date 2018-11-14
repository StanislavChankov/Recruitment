using System;
using System.Linq.Expressions;

using Synergy.Recruitment.Business.Models.Person;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Business.Factories
{
    /// <summary>
    /// The factory class containing static methods for instantiating <see cref="Person"/> related instances.
    /// </summary>
    public static class PersonFactory
    {
        /// <summary>
        /// Gets the <see cref="PersonOrganization"/> out of <see cref="Person"/>.
        /// </summary>
        public static Expression<Func<Person, PersonOrganization>> GetPersonOrganization
            => person
                => new PersonOrganization
                {
                    Id = person.Id,
                    FirstName = person.FirstName,
                    LastName = person.LastName,
                    EmailAddress = person.EmailAddress,
                    BirthDate = person.BirthDate,
                    OrganizationId = person.SystemUser.OrganizationId
                };

        public static Expression<Func<Person, bool>> GetPersonById(long userId)
            => person
                => person.SystemUser.Id == userId;
    }
}
