using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Models
{
    public class Country
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}
