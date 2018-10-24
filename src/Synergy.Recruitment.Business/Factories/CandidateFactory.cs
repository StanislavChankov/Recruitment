using System;
using System.Linq;

using Synergy.Recruitment.Data.Models;
using Synergy.Recruitment.Rest.Models.Candidate;

namespace Synergy.Recruitment.Business.Factories
{
    /// <summary>
    /// The factory class containing static methods for instantiating <see cref="Candidate"/> related instances.
    /// </summary>
    public class CandidateFactory
    {
        /// <summary>
        /// Gets the <see cref="CandidateResponse"/> out of <see cref="Candidate"/>.
        /// </summary>
        public static Func<Candidate, CandidateResponse> GetCandidateResponse
            => technology
                => new CandidateResponse
                {
                    Id = technology.Id,
                    // FirstName = technology.FirstName,
                    // LastName = technology.LastName,
                    // Position = MockFactory.GetPositions().FirstOrDefault(p => p.Id == technology.PositionId).Name,
                    UpdatedOn = technology.UpdatedOn,
                };
    }
}
