using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Business.Models.Person;
using Synergy.Recruitment.Data.Models.Identity;

namespace Synergy.Recruitment.Test.Factories
{
    [TestClass]
    [TestCategory("Person")]
    public class PersonFactoryTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetPersons))]
        public void GetTechnologyResponse_InstantiateCorrectly(Tuple<Person, PersonOrganization> data)
        {
            var result = PersonFactory.GetPersonOrganization.Compile()(data.Item1);

            Assert.AreEqual(data.Item2.Id, result.Id);
            Assert.AreEqual(data.Item2.FirstName, result.FirstName);
            Assert.AreEqual(data.Item2.LastName, result.LastName);
            Assert.AreEqual(data.Item2.OrganizationId, result.OrganizationId);
            Assert.AreEqual(data.Item2.SystemUserId, result.SystemUserId);
            Assert.AreEqual(data.Item2.BirthDate, result.BirthDate);
            Assert.AreEqual(data.Item2.EmailAddress, result.EmailAddress);
        }

        [DataTestMethod]
        [DynamicData(nameof(GetPeople))]
        public void GetPersonById_FilterCorrectly(Tuple<bool, Person> data)
        {
            var selector = PersonFactory.GetPersonById(1).Compile();
            var result = selector(data.Item2);

            Assert.AreEqual(data.Item1, result);
        }

        #region Private Mock Methods

        private static IEnumerable<object[]> GetPeople
            => new[]
            {
                new object[]
                {
                    new Tuple<bool, Person>
                    (
                        true,
                        new Person { SystemUser = new SystemUser { Id = 1 } }
                    )
                },
                new object[]
                {
                    new Tuple<bool, Person>
                    (
                        false,
                        new Person { SystemUser = new SystemUser { Id = 2 } }
                    ),
                },
                new object[]
                {
                    new Tuple<bool, Person>
                    (
                        false,
                        new Person { SystemUser = new SystemUser { Id = 0 } }
                    ),
                },
                new object[]
                {
                    new Tuple<bool, Person>
                    (
                        false,
                        new Person { SystemUser = new SystemUser { Id = -1 }}
                    ),
                }
            };


        private static IEnumerable<object[]> GetPersons
            => new[]
            {
                new object[]
                {
                    new Tuple<Person, PersonOrganization>
                    (
                        new Person { Id = 1, FirstName = "TestFirstName", SystemUser = GetSystemUser() },
                        new PersonOrganization { Id = 1, FirstName = "TestFirstName", OrganizationId = 2 }
                    )
                },
                new object[]
                {
                    new Tuple<Person, PersonOrganization>
                    (
                        new Person { Id = 2, FirstName = "", IsActive = false, EmailAddress = null, SystemUser = GetSystemUser() },
                        new PersonOrganization { Id = 2, FirstName = "", EmailAddress = null, OrganizationId = 2 }
                    ),
                },
                new object[]
                {
                    new Tuple<Person, PersonOrganization>
                    (
                        new Person { Id = 0, FirstName = null, LastName = null, EmailAddress = "random@gmail.com", SystemUser = GetSystemUser() },
                        new PersonOrganization { Id = 0, FirstName = null, LastName = null, EmailAddress = "random@gmail.com", OrganizationId = 2 }
                    ),
                },
                new object[]
                {
                    new Tuple<Person, PersonOrganization>
                    (
                        new Person { Id = -1, FirstName = "TestFirstName", LastName = "TestLastName", IsActive = true, EmailAddress = string.Empty, SystemUser = GetSystemUser() },
                        new PersonOrganization { Id = -1, FirstName = "TestFirstName", LastName = "TestLastName", EmailAddress = string.Empty, OrganizationId = 2 }
                    ),
                },
            };

        private static SystemUser GetSystemUser()
            => new SystemUser
            {
                Id = 1,
                OrganizationId = 2,
                PersonId = 3
            };

        #endregion
    }
}
