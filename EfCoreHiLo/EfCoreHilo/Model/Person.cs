// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace EfCoreHilo.Model
{
    /// <summary>
    /// A Person in the application.
    /// </summary>
    public partial class Person : Entity
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public required string FullName { get; set; }

        /// <summary>
        /// Gets or sets the Preferred Name.
        /// </summary>
        public required string PreferredName { get; set; }

        /// <summary>
        /// Gets or sets the Email Address.
        /// </summary>
        public string? Email { get; set; }
    }
}
