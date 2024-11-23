// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace EfCoreHilo.Model
{
    /// <summary>
    /// An Address in the application.
    /// </summary>
    public partial class Address : Entity
    {
        /// <summary>
        /// Gets or sets the AddressLine 1
        /// </summary>
        public required string AddressLine1 { get; set; }

        /// <summary>
        /// Gets or sets the Address Line 2 (optional)
        /// </summary>
        public string? AddressLine2 { get; set; }

        /// <summary>
        /// Gets or sets the Postal Code (optional)
        /// </summary>
        public string? PostalCode { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        public required string City { get; set; }
    }
}
