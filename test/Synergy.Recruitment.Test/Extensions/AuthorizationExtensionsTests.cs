using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Synergy.Recruitment.Core.Extensions;

namespace Synergy.Recruitment.Test.Extensions
{
    [TestClass]
    [TestCategory("Extension")]
    public class AuthorizationExtensionsTests
    {
        [DataTestMethod]
        [DynamicData(nameof(GetCalculations))]
        public void CalculateActionsInteger_CorrectBigInt(Tuple<IEnumerable<short>, BigInteger> data)
        {
            BigInteger result = data.Item1.CalculateActionsInteger();

            Assert.AreEqual(data.Item2, result);
        }

        private static IEnumerable<object[]> GetCalculations
            => new[]
            {
                new object[]
                {
                    new Tuple<IEnumerable<short>, BigInteger>
                    (
                        new short[]{ 1, 2, 3, 4 },
                        30
                    )
                },
                new object[]
                {
                    new Tuple<IEnumerable<short>, BigInteger>
                    (
                        new short[]{ 1, 3, 5, 7 },
                        170
                    ),
                },
                new object[]
                {
                    new Tuple<IEnumerable<short>, BigInteger>
                    (
                        new short[]{ 10, 15, 20, 30 },
                        1074824192
                    ),
                },
                new object[]
                {
                    new Tuple<IEnumerable<short>, BigInteger>
                    (
                        new short[]{ 2, 4, 6, 8, 10 },
                        1364
                    ),
                },
            };
    }
}
