namespace Synergy.Recruitment.Business.Models.Users
{
    public class UserPassword
    {
        public long Id { get; set; }

        public string PasswordHash { get; set; }

        public string PasswordSalt { get; set; }
    }
}
