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
                new Technology { Id = 1, Name = "TypeScript" },
                new Technology { Id = 1, Name = "JavaScript" },
                new Technology { Id = 1, Name = "Angular" },
                new Technology { Id = 1, Name = "React" },
                new Technology { Id = 1, Name = "Vue" },
            };

        public static IEnumerable<Candidate> GetCandidates()
            => new List<Candidate>
            {
                new Candidate { Id = 1, FirstName = "George", LastName = "", PositionId = 1, UpdatedOn = DateTime.Now.AddDays(-1) },
                new Candidate { Id = 2, FirstName = "George", LastName = "", PositionId = 1, UpdatedOn = DateTime.Now.AddDays(-1) },
                new Candidate { Id = 3, FirstName = "George", LastName = "", PositionId = 1, UpdatedOn = DateTime.Now.AddDays(-1) },
                new Candidate { Id = 4, FirstName = "George", LastName = "", PositionId = 1, UpdatedOn = DateTime.Now.AddDays(-1) },
                new Candidate { Id = 5, FirstName = "George", LastName = "", PositionId = 1, UpdatedOn = DateTime.Now.AddDays(-1) },
                new Candidate { Id = 6, FirstName = "George", LastName = "", PositionId = 1, UpdatedOn = DateTime.Now.AddDays(-1) }
            };
    }
}
