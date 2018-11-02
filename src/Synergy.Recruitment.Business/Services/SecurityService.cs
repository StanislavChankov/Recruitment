using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

using Synergy.Recruitment.Core.Services;

namespace Synergy.Recruitment.Business.Services
{
    /// <summary>
    /// The default <see cref="ISecurityService"/> implementation.
    /// </summary>
    public class SecurityService : ISecurityService
    {
        #region Fields

        private const int SALT_SIZE = 16;
        private const int RANDOM_PASSWORD_LENGTH = 8;
        private const string PASSWORD_CHARS = "ABCDEFGHJKLMNPQRTUVWXYZ2346789";
        private static Random _random = new Random();

        #endregion

        #region Public methods

        /// See <see cref="ISecurityService" /> for more.
        public string GenerateSalt()
        {
            byte[] saltBytes = CreateSalt();

            var saltString = Convert.ToBase64String(saltBytes);

            return saltString;
        }

        /// See <see cref="ISecurityService" /> for more.
        public string GetHashedPassword(string plainText, string salt)
        {
            plainText = plainText ?? throw new ArgumentNullException(nameof(plainText));
            salt = salt ?? throw new ArgumentNullException(nameof(plainText));

            byte[] passwordBytes = GenerateSaltedHash(plainText, salt);

            var saltedHashString = Convert.ToBase64String(passwordBytes);

            return saltedHashString;
        }

        /// See <see cref="ISecurityService" /> for more.
        public string GenerateRandomPassword()
        {
            return new string(Enumerable.Repeat(PASSWORD_CHARS, RANDOM_PASSWORD_LENGTH)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        #endregion

        #region Private methods

        private byte[] CreateSalt()
        {
            var rng = RandomNumberGenerator.Create();
            byte[] buff = new byte[SALT_SIZE];

            rng.GetBytes(buff);

            return buff;
        }

        private byte[] GenerateSaltedHash(string plainText, string salt)
        {
            var utf8Encoding = new UTF8Encoding();

            byte[] saltBytes = utf8Encoding.GetBytes(salt);

            byte[] plainTextBytes = utf8Encoding.GetBytes(plainText);

            HashAlgorithm algorithm = SHA256.Create();

            byte[] plainTextWithSaltBytes = new byte[plainTextBytes.Length + saltBytes.Length];

            for (int i = 0; i < plainTextBytes.Length; i++)
            {
                plainTextWithSaltBytes[i] = plainTextBytes[i];
            }

            for (int i = 0; i < saltBytes.Length; i++)
            {
                plainTextWithSaltBytes[plainTextBytes.Length + i] = saltBytes[i];
            }

            return algorithm.ComputeHash(plainTextWithSaltBytes);
        }

        #endregion
    }
}
