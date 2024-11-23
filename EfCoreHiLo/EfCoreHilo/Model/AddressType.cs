// Licensed under the MIT license. See LICENSE file in the project root for full license information.

namespace EfCoreHilo.Model
{
    /// <summary>
    /// An AddressType in the application.
    /// </summary>
    public partial class AddressType : Entity
    {
        /// <summary>
        /// Gets or sets the Name.
        /// </summary>
        public required string Name { get; set; }
    }
}
