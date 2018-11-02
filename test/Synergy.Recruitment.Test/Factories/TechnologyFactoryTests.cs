using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Data.Models;
using Synergy.Recruitment.Rest.Models.Technology;

namespace Synergy.Recruitment.Test.Factories
{
    [TestClass]
    [TestCategory("Technology")]
    public class TechnologyFactoryTests
    {
        #region Tests

        [DataTestMethod]
        [DynamicData(nameof(GetTechnologies))]
        public void GetTechnologyResponse_InstantiateCorrectly(Tuple<Technology, TechnologyResponse> data)
        {
            TechnologyResponse result = TechnologyFactory.GetTechnologyResponse(data.Item1);

            Assert.AreEqual(data.Item2.Id, result.Id);
            Assert.AreEqual(data.Item2.Name, result.Name);
        }

        #endregion

        #region Private Mock Methods

        private static IEnumerable<object[]> GetTechnologies
            => new[]
            {
                new object[]
                {
                    new Tuple<Technology, TechnologyResponse>
                    (
                        new Technology { Id = 1, Name = "Cutting Edge Technology" },
                        new TechnologyResponse { Id = 1, Name = "Cutting Edge Technology" }
                    )
                },
                new object[]
                {
                    new Tuple<Technology, TechnologyResponse>
                    (
                        new Technology { Id = 2, Name = string.Empty },
                        new TechnologyResponse { Id = 2, Name = string.Empty }
                    ),
                },
                new object[]
                {
                    new Tuple<Technology, TechnologyResponse>
                    (
                        new Technology { Id = 0, Name = null },
                        new TechnologyResponse { Id = 0, Name = null }
                    ),
                }
            };

        #endregion
    }
}
