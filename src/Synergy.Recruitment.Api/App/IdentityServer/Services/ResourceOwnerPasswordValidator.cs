using System.Threading.Tasks;

using IdentityServer4.Models;
using IdentityServer4.Validation;

using Synergy.Recruitment.Business.Models.Users;
using Synergy.Recruitment.Core.Services.Identity;

namespace Synergy.Recruitment.Api.App.IdentityServer.Services
{
    /// <summary>
    /// The resource password provider.
    /// </summary>
    /// <seealso cref="IdentityServer4.Validation.IResourceOwnerPasswordValidator" />
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        #region Constants

        private const string PasswordAuthenticationMethod = "password";

        #endregion

        #region Fields


        private readonly IUserService _userService;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceOwnerPasswordValidator"/> class.
        /// </summary>
        public ResourceOwnerPasswordValidator(IUserService userService)
        {
            _userService = userService;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Validates user credentials asynchronously.
        /// </summary>
        /// <param name="context">The context.</param>
        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            UserPassword user = await _userService.ValidateCredentialsAsync(context.UserName, context.Password);
        
            if (user != null)
            {
                context.Result = new GrantValidationResult(user.Id.ToString(), PasswordAuthenticationMethod, claims: null);
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidGrant);
            }
        }

        #endregion
    }
}