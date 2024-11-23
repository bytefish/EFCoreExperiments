// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace EfCoreAudit.Temporal.Model
{
    /// <summary>
    /// A Person in the application.
    /// </summary>
    public partial class PersonAddress : Entity
    {
        /// <summary>
        /// Gets or sets the Person.
        /// </summary>
        public required int PersonId { get; set; }

        /// <summary>
        /// Gets or sets the Address.
        /// </summary>
        public required int AddressId { get; set; }

        /// <summary>
        /// Gets or sets the AddressType.
        /// </summary>
        public required AddressTypeEnum AddressType { get; set; }
    }
}
