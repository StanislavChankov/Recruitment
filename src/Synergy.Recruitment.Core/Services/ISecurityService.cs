namespace Synergy.Recruitment.Core.Services
{
    /// <summary>
    /// The security service interface.
    /// </summary>
    public interface ISecurityService
    {
        /// <summary>
        /// Creates the salt.
        /// </summary>
        string GenerateSalt();

        /// <summary>
        /// Gets the hashed password.
        /// </summary>
        /// <param name="plainText">The plain text.</param>
        /// <param name="salt">The salt.</param>
        string GetHashedPassword(string plainText, string salt);

        /// <summary>
        /// Generates the random password.
        /// </summary>
        string GenerateRandomPassword();
    }
}
