using System;
using Synergy.Recruitment.Data.Models;
using Synergy.Recruitment.Rest.Models.Technology;

namespace Synergy.Recruitment.Business.Factories
{
    /// <summary>
    /// The factory class containing static methods for instantiating <see cref="Technology"/> related instances.
    /// </summary>
    public static class TechnologyFactory
    {
        /// <summary>
        /// Gets the <see cref="TechnologyResponse"/> out of <see cref="Technology"/>.
        /// </summary>
        public static Func<Technology, TechnologyResponse> GetTechnologyResponse
            => technology
                => new TechnologyResponse
                {
                    Id = technology.Id,
                    Name = technology.Name
                };
    }
}
