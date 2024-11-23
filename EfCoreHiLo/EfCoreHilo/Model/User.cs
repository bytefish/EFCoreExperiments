// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace EfCoreAudit.Temporal.Model
{
    /// <summary>
    /// A User in the application.
    /// </summary>
    public partial class User : Entity
    {
        /// <summary>
        /// Gets or sets the Full Name.
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// Gets or sets the Preferred Name.
        /// </summary>
        public required string PreferredName { get; set; }

        /// <summary>
        /// Gets or sets the Is Permitted To Logon.
        /// </summary>
        public required bool IsPermittedToLogon { get; set; }

        /// <summary>
        /// Gets or sets the Logon Name.
        /// </summary>
        public string? LogonName { get; set; };

        /// <summary>
        /// Gets or sets the Hashed Password.
        /// </summary>
        public string? HashedPassword { get; set; }
    }
}
