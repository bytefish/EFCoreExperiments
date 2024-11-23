// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using EfCoreAudit.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace EfCoreAudit.Database.Interceptors
{
    /// <summary>
    /// A <see cref="SaveChangesInterceptor"/> for adding auditing metadata.
    /// </summary>
    internal class AuditingInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            DbContext ctx = eventData.Context!;

            if (ctx == null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            var auditableEntities = ctx.ChangeTracker.Entries<AuditableEntity>().ToList();

            foreach (var auditableEntity in auditableEntities)
            {

                if (auditableEntity.State == EntityState.Added)
                {
                    auditableEntity.Property(x => x.CreatedDateTime).CurrentValue = DateTime.UtcNow;
                }

                if (auditableEntity.State == EntityState.Modified)
                {
                    auditableEntity.Property(x => x.ModifiedDateTime).CurrentValue = DateTime.UtcNow;
                }
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }
}
