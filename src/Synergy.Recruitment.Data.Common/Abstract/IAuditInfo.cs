using System;

namespace Synergy.Recruitment.Data.Common.Abstract
{
    public interface IAuditInfo
    {
        /// <summary>
        /// Gets or sets the created <see cref="DateTime"/> of this entity.
        /// </summary>
        DateTime CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the modified <see cref="DateTime"/> of this entity.
        /// </summary>
        DateTime? ModifiedOn { get; set; }
    }
}
