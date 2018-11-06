using System;
using System.Collections.Generic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Synergy.Recruitment.Core.Extensions;

namespace Synergy.Recruitment.Test.Extensions
{
    [TestClass]
    [TestCategory("Extension")]
    public class StringExtentionsTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetSimilar))]
        public void IsSimilarTo_ComparesCorrectly(Tuple<string, string, bool> data)
        {
            bool result = data.Item1.IsSimilarTo(data.Item2);

            Assert.AreEqual(data.Item3, result);
        }

        private static IEnumerable<object[]> GetSimilar
            => new[]
            {
                new object[]
                {
                    new Tuple<string, string, bool>
                    (
                        "tEsT",
                        "TEST",
                        true
                    )
                },
                new object[]
                {
                    new Tuple<string, string, bool>
                    (
                        "different",
                        "test",
                        false
                    ),
                },
                new object[]
                {
                    new Tuple<string, string, bool>
                    (
                        "same",
                        "same",
                        true
                    ),
                },
                new object[]
                {
                    new Tuple<string, string, bool>
                    (
                        "SAME",
                        "SAME",
                        true
                    ),
                },
            };
    }
}
