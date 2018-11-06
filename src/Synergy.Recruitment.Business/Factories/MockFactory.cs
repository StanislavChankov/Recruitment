using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Synergy.Recruitment.Core.Extensions;
using Synergy.Recruitment.Data.Models;
using Synergy.Recruitment.Rest.Models.Candidate;

namespace Synergy.Recruitment.Business.Factories
{
    /// <summary>
    /// Contains static mock methods.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public static class MockFactory
    {
        public static IEnumerable<Technology> GetTechnologies()
            => new List<Technology>
            {
                new Technology { Id = 1, Name = ".NET" },
                new Technology { Id = 2, Name = "TypeScript" },
                new Technology { Id = 3, Name = "JavaScript" },
                new Technology { Id = 4, Name = "Angular" },
                new Technology { Id = 5, Name = "React" },
                new Technology { Id = 6, Name = "Vue" },
                new Technology { Id = 7, Name = "Java" },
            };

        public static IEnumerable<Position> GetPositions()
            => new List<Position>
            {
                new Position { Id = 1, Name = ".Net Developer" },
                new Position { Id = 2, Name = "Junior .Net Developer" },
                new Position { Id = 3, Name = "Senior .Net Developer" },

                new Position { Id = 4, Name = "Senior Java Developer" },
                new Position { Id = 5, Name = "Junior Java Developer" },
                new Position { Id = 6, Name = "Java Developer" },

                new Position { Id = 7, Name = "Junior QA" },
                new Position { Id = 8, Name = "QA Analyst" },
                new Position { Id = 9, Name = "QA Specialist" },
                new Position { Id = 10, Name = "Senior QA" },

                new Position { Id = 11, Name = "Junior Business Analyst" },
                new Position { Id = 12, Name = "Business Analyst" },

                new Position { Id = 13, Name = "DB Developer" },
                new Position { Id = 14, Name = "Junior Developer" },
                new Position { Id = 15, Name = "Senior DB Developer" },
            };

        public static IEnumerable<CandidateResponse> GetCandidates()
            => new List<CandidateResponse>
            {
                new CandidateResponse { Id = 1, FirstName = "Marcia", LastName = "Cantu", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-1).AddHours(-1).AddMinutes(1) },
                new CandidateResponse { Id = 2, FirstName = "Ryder", LastName = "Nicholson", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-2).AddHours(-2).AddMinutes(-2) },
                new CandidateResponse { Id = 3, FirstName = "Eloisa", LastName = "Wise", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-3).AddHours(-3).AddMinutes(-3) },
                new CandidateResponse { Id = 4, FirstName = "Johnathon", LastName = "Fountain", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-4).AddHours(-1).AddMinutes(-4) },
                new CandidateResponse { Id = 5, FirstName = "Lyra", LastName = "Thomas", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-5).AddMinutes(1) },
                new CandidateResponse { Id = 6, FirstName = "Lacy", LastName = "Reilly", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-6).AddMinutes(-6) },
                new CandidateResponse { Id = 7, FirstName = "Tiya", LastName = "Atkins", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-7).AddMinutes(-7) },
                new CandidateResponse { Id = 8, FirstName = "Harris", LastName = "Weir", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-8).AddMinutes(8) },
                new CandidateResponse { Id = 9, FirstName = "Cassia", LastName = "Livingston", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-9) },
                new CandidateResponse { Id = 10, FirstName = "Tehya", LastName = "Brooks", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddSeconds(-2) },
                new CandidateResponse { Id = 11, FirstName = "Herbie", LastName = "Major", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddSeconds(-15) },
                new CandidateResponse { Id = 12, FirstName = "Morwenna", LastName = "Mcdonald", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-12) },
                new CandidateResponse { Id = 13, FirstName = "Mariyah", LastName = "Guerrero", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-13) },
                new CandidateResponse { Id = 14, FirstName = "Caden", LastName = "Turnbull", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-14) },
                new CandidateResponse { Id = 15, FirstName = "Fearne", LastName = "Cox", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-15) },
                new CandidateResponse { Id = 16, FirstName = "Zoey", LastName = "Ashley", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-16) },
                new CandidateResponse { Id = 17, FirstName = "Luqman", LastName = "Davila", Position = GetRandomPosition(), UpdatedOn = DateTime.Now.AddDays(-17) },
            };

        private static string GetRandomPosition()
            => GetPositions().PickRandom().Name;
    }
}
