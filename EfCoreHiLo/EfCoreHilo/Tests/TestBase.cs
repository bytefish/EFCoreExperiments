// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EfCoreHilo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EfCoreHilo.Tests
{
    /// <summary>
    /// Will be used by all integration tests, that need an <see cref="ApplicationDbContext"/>.
    /// </summary>
    internal class TestBase
    {
        /// <summary>
        /// We can assume the Configuration has been initialized, when the Tests 
        /// are run. So we inform the compiler, that this field is intentionally 
        /// left uninitialized.
        /// </summary>
        protected IConfiguration _configuration = null!;

        public TestBase()
        {
            _configuration = ReadConfiguration();
        }

        /// <summary>
        /// Read the appsettings.json for the Test.
        /// </summary>
        /// <returns></returns>
        private IConfiguration ReadConfiguration()
        {
            return new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        /// <summary>
        /// Builds an <see cref="ApplicationDbContext"/> based on a given Configuration. We 
        /// expect the Configuration to have a Connection String "ApplicationDatabase" to 
        /// be defined.
        /// </summary>
        /// <param name="configuration">A configuration provided by the appsettings.json</param>
        /// <returns>An initialized <see cref="ApplicationDbContext"/></returns>
        /// <exception cref="InvalidOperationException">Thrown when no Connection String "ApplicationDatabase" was found</exception>
        protected ApplicationDbContext CreateDbContext()
        {
            var connectionString = _configuration.GetConnectionString("ApplicationDatabase");

            if (connectionString == null)
            {
                throw new InvalidOperationException($"No Connection String named 'ApplicationDatabase' found in appsettings.json");
            }

            var dbContextOptionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlServer(connectionString);

            return new ApplicationDbContext(dbContextOptionsBuilder.Options);
        }
    }
}