namespace Synergy.Recruitment.Data.Models.Identity
{
    public class SystemUserPassword
    {
        public long Id { get; set; }

        public long SystemUserId { get; set; }

        public string Password { get; set; }

        public string PasswordSalt { get; set; }

        public SystemUser SystemUser { get; set; }
    }
}
