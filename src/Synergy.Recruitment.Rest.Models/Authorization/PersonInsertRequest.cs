using System.ComponentModel.DataAnnotations;

namespace Synergy.Recruitment.Rest.Models.Authorization
{
    public class PersonInsertRequest
    {
        [Required]
        public string EmailAddress { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }
    }
}
