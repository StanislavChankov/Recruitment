using System;
using System.Collections.Generic;
using Synergy.Recruitment.Data.Models;

namespace Synergy.Recruitment.Business.Factories
{
    /// <summary>
    /// Contains static mock methods.
    /// </summary>
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

        public static IEnumerable<Candidate> GetCandidates()
            => new List<Candidate>
            {
                new Candidate { Id = 1, FirstName = "Marcia", LastName = "Cantu", PositionId = 1, UpdatedOn = DateTime.Now.AddDays(-1).AddHours(-1).AddMinutes(1) },
                new Candidate { Id = 2, FirstName = "Ryder", LastName = "Nicholson", PositionId = 2, UpdatedOn = DateTime.Now.AddDays(-2).AddHours(-2).AddMinutes(-2) },
                new Candidate { Id = 3, FirstName = "Eloisa", LastName = "Wise", PositionId = 3, UpdatedOn = DateTime.Now.AddDays(-3).AddHours(-3).AddMinutes(-3) },
                new Candidate { Id = 4, FirstName = "Johnathon", LastName = "Fountain", PositionId = 4, UpdatedOn = DateTime.Now.AddDays(-4).AddHours(-1).AddMinutes(-4) },
                new Candidate { Id = 5, FirstName = "Lyra", LastName = "Thomas", PositionId = 5, UpdatedOn = DateTime.Now.AddDays(-5).AddMinutes(1) },
                new Candidate { Id = 6, FirstName = "Lacy", LastName = "Reilly", PositionId = 6, UpdatedOn = DateTime.Now.AddDays(-6).AddMinutes(-6) },
                new Candidate { Id = 7, FirstName = "Tiya", LastName = "Atkins", PositionId = 7, UpdatedOn = DateTime.Now.AddDays(-7).AddMinutes(-7) },
                new Candidate { Id = 8, FirstName = "Harris", LastName = "Weir", PositionId = 8, UpdatedOn = DateTime.Now.AddDays(-8).AddMinutes(8) },
                new Candidate { Id = 9, FirstName = "Cassia", LastName = "Livingston", PositionId = 9, UpdatedOn = DateTime.Now.AddDays(-9) },
                new Candidate { Id = 10, FirstName = "Tehya", LastName = "Brooks", PositionId = 10, UpdatedOn = DateTime.Now.AddSeconds(-2) },
                new Candidate { Id = 11, FirstName = "Herbie", LastName = "Major", PositionId = 11, UpdatedOn = DateTime.Now.AddSeconds(-15) },
                new Candidate { Id = 12, FirstName = "Morwenna", LastName = "Mcdonald", PositionId = 12, UpdatedOn = DateTime.Now.AddDays(-12) },
                new Candidate { Id = 13, FirstName = "Mariyah", LastName = "Guerrero", PositionId = 13, UpdatedOn = DateTime.Now.AddDays(-13) },
                new Candidate { Id = 14, FirstName = "Caden", LastName = "Turnbull", PositionId = 14, UpdatedOn = DateTime.Now.AddDays(-14) },
                new Candidate { Id = 15, FirstName = "Fearne", LastName = "Cox", PositionId = 15, UpdatedOn = DateTime.Now.AddDays(-15) },
                new Candidate { Id = 16, FirstName = "Zoey", LastName = "Ashley", PositionId = 1, UpdatedOn = DateTime.Now.AddDays(-16) },
                new Candidate { Id = 17, FirstName = "Luqman", LastName = "Davila", PositionId = 2, UpdatedOn = DateTime.Now.AddDays(-17) },
            };
    }
}
