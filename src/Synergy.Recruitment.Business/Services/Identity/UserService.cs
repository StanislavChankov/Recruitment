using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Synergy.Recruitment.Business.Factories;
using Synergy.Recruitment.Business.Models.Authorization;
using Synergy.Recruitment.Business.Models.Organizations;
using Synergy.Recruitment.Business.Models.RoleActions;
using Synergy.Recruitment.Business.Models.Roles;
using Synergy.Recruitment.Business.Models.Users;
using Synergy.Recruitment.Core.Extensions;
using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Core.Services;
using Synergy.Recruitment.Core.Services.Identity;
using Synergy.Recruitment.Core.Services.Master;
using Synergy.Recruitment.Data.Models.Identity;
using Synergy.Recruitment.Resources;
using Synergy.Recruitment.Rest.Models.Authorization;

namespace Synergy.Recruitment.Business.Services.Identity
{
    public class UserService : IUserService
    {
        #region Fields

        private readonly ISecurityService _securityService;
        private readonly IUserRoleService _userRoleService;
        private readonly IUserOrganizationService _userOrganizationService;
        private readonly IRoleActionMasterService _roleActionMasterService;

        private readonly IUserRepository _userRepository;
        private readonly IUserPasswordRepository _userPasswordRepository;
        private readonly IRoleActionOrganizationRepository _roleActionOrganizationRepository;

        #endregion

        #region Constructors

        public UserService(
            ISecurityService securityService,
            IUserRoleService userRoleService,
            IUserOrganizationService userOrganizationService,
            IRoleActionMasterService roleActionMasterService,
            IUserRepository userRepository,
            IUserPasswordRepository userPasswordRepository,
            IRoleActionOrganizationRepository roleActionOrganizationRepository)
        {
            _securityService = securityService;
            _userRoleService = userRoleService;
            _userOrganizationService = userOrganizationService;
            _roleActionMasterService = roleActionMasterService;

            _userRepository = userRepository;
            _userPasswordRepository = userPasswordRepository;
            _roleActionOrganizationRepository = roleActionOrganizationRepository;
        }

        #endregion

        public async Task<UserPassword> ValidateCredentialsAsync(string emailAddress, string password)
        {
            emailAddress = emailAddress ?? throw new ArgumentNullException(nameof(emailAddress));
            password = password ?? throw new ArgumentNullException(nameof(password));

            var selectExp = UserFactory.GetUserByEmail(emailAddress, default(bool?));

            UserPassword user = await _userRepository.GetByEmailAsync(UserFactory.GetPersonOrganization, selectExp);

            string hashedPassword = _securityService.GetHashedPassword(password, user.PasswordSalt);

            if (hashedPassword.IsSimilarTo(user.PasswordHash))
            {
                return user;
            }

            return await Task.FromResult(default(UserPassword));
        }

        public async Task CreateUserOrganizationAsync(UserOrganizationInsertRequest userOrganization)
        {
            RoleLogic role = await _userRoleService.GetByRoleCodeAsync(Constants.DirectorRole);
            
            HashedPassword hashedPass = _securityService.GetHashedPassword(userOrganization.Person.Password);
            SystemUserPassword userPassword = UserFactory.GetUserPassword(userOrganization, role.RoleId, hashedPass);

            // Inserts new SystemUser, SystemUserPassword, Person, Organization
            await _userPasswordRepository.InsertAsync(userPassword);

            Task<OrganizationLogic> organizationTask = _userOrganizationService.GetByNameAsync(userOrganization.OrganizationName);
            Task<IEnumerable<DefaultRoleActionLogic>> roleActionsTask = _roleActionMasterService.GetAllDefaultAsync();

            await Task.WhenAll(organizationTask, roleActionsTask);

            IEnumerable<RoleActionOrganization> roleActionOrganizations = roleActionsTask.Result.Select(
                dro => RoleActionOrganizationFactory.GetRoleActionOrganization(organizationTask.Result.Id, dro.RoleId, dro.ActionId));

            /// Inserts into RoleActionOrganization the records from DefaultRoleAction, but for the new organization.
            await _roleActionOrganizationRepository.InsertRangeAsync(roleActionOrganizations);
        }
    }
}
