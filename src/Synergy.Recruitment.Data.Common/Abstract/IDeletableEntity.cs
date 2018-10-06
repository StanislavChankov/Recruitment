using System;

namespace Synergy.Recruitment.Data.Common.Abstract
{
    public interface IDeletableEntity
    {
        /// <summary>
        /// Gets or sets a value indicating whether this entity instance is deleted.
        /// </summary>
        /// <value>
        ///   <c>true</c> if this instance is deleted; otherwise, <c>false</c>.
        /// </value>
        bool IsDeleted { get; set; }

        /// <summary>
        /// Gets or sets the deleted <see cref="DateTime"/> of this entity.
        /// </summary>
        DateTime? DeletedOn { get; set; }
    }
}
