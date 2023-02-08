// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace EfCoreAudit.Model
{
    /// <summary>
    /// A Person in the application.
    /// </summary>
    internal class Person : IAuditableEntity
    {
        /// <summary>
        /// Gets or sets the Id.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public required string FullName { get; set; }
    }
}
