using System;
using Synergy.Recruitment.Data.Abstract;
using Synergy.Recruitment.Data.Models.Abstract;

namespace Synergy.Recruitment.Data.Models.Identity
{
    public class SystemUser : BaseEntity, IAuditInfo
    {
        public long PersonId { get; set; }

        public long OrganizationId { get; set; }

        public long RoleId { get; set; }

        /// <summary>
        /// Gets or sets the created <see cref="DateTime"/> of this entity.
        /// </summary>
        public DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the modified <see cref="DateTime"/> of this entity.
        /// </summary>
        public DateTime? ModifiedOnUtc { get; set; }

        //public long SystemUserPasswordId { get; set; }

        public Person Person { get; set; }

        public Role Role { get; set; }

        public Organization Organization { get; set; }

        public SystemUserPassword SystemUserPassword { get; set; }
    }
}
