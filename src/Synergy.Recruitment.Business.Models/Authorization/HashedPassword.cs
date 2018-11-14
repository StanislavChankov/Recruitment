namespace Synergy.Recruitment.Business.Models.Authorization
{
    public class HashedPassword
    {
        public string PasswordHash { get; set; }

        public string Salt { get; set; }
    }
}
