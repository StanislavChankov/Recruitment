using System.ComponentModel.DataAnnotations;

namespace Synergy.Recruitment.Rest.Models.Authorization
{
    public class UserOrganizationInsertRequest
    {
        [Required]
        public string OrganizationName { get; set; }

        [Required]
        public PersonInsertRequest Person { get; set; }
    }
}
