﻿using System.Threading.Tasks;
using System.Linq;

using Synergy.Recruitment.Core.Repositories.Identity;
using Synergy.Recruitment.Data.Common.Abstract;
using Synergy.Recruitment.Data.Data;
using Synergy.Recruitment.Data.Models.Identity;

using Microsoft.EntityFrameworkCore;

using System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Synergy.Recruitment.Data.Repositories.Identity
{
    public class UserRepository : EFCoreRepository<SystemUser>, IUserRepository
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonRepository"/> class.
        /// </summary>
        public UserRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        #endregion

        public Task<TResult> GetByEmailAsync<TResult>(
            Expression<Func<SystemUser, TResult>> projectionExp,
            Expression<Func<SystemUser, bool>> selectionExp)
                => Queryable
                    .Where(selectionExp)
                    .Select(projectionExp)
                    .FirstOrDefaultAsync();

        public Task<List<short>> GetActionsAsync(Expression<Func<SystemUser, bool>> selectionExp)
            => Queryable
                .Where(selectionExp)
                .SelectMany(su => su.Role.RoleActionOrganizations)
                .Select(rao => rao.Action.ActionEnum)
                .ToListAsync();

        public Task InsertAsync(SystemUser user) => AddAsync(user);
    }
}
