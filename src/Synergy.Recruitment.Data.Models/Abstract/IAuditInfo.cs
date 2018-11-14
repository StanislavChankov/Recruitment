using System;

namespace Synergy.Recruitment.Data.Abstract
{
    public interface IAuditInfo
    {
        /// <summary>
        /// Gets or sets the created <see cref="DateTime"/> of this entity.
        /// </summary>
        DateTime CreatedOnUtc { get; set; }

        /// <summary>
        /// Gets or sets the modified <see cref="DateTime"/> of this entity.
        /// </summary>
        DateTime? ModifiedOnUtc { get; set; }
    }
}
