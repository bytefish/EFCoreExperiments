// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace EfCoreAudit.Model
{
    /// <summary>
    /// Audit Information.
    /// </summary>
    public abstract class AuditableEntity
    {
        /// <summary>
        /// Gets or sets the created date.
        /// </summary>
        public DateTime? CreatedDateTime { get; set; }

        /// <summary>
        /// Gets or sets the modified date.
        /// </summary>
        public DateTime? ModifiedDateTime { get; set; }
    }
}
