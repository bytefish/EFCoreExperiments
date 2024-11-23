// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EfCoreHilo.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EfCoreHilo.Services
{
    public class AddressManagementService
    {
        private readonly ILogger<AddressManagementService> _logger;

        private readonly IDbContextFactory<ApplicationDbContext> _dbContextFactory;

        public AddressManagementService(ILogger<AddressManagementService> logger, IDbContextFactory<ApplicationDbContext> dbContextFactory)
        {
            _logger = logger;
            _dbContextFactory = dbContextFactory;
        }


    }
}
