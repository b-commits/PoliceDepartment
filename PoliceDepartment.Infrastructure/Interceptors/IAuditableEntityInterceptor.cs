using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;
using PoliceDepartment.Core.Primitives;

namespace PoliceDepartment.Infrastructure.Interceptors;

internal sealed class AuditableEntityInterceptor(ILogger<AuditableEntityInterceptor> logger) : SaveChangesInterceptor
{
    public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result,
        CancellationToken cancellationToken = new())
    {
        var dbContext = eventData.Context;

        if (dbContext is null)
            return base.SavingChangesAsync(eventData, result, cancellationToken);

        var auditableEntries = dbContext.ChangeTracker.Entries<IAuditableEntity>();
        
        foreach (var auditableEntry in auditableEntries)
        {
            if (auditableEntry.State == EntityState.Added)
            {
                auditableEntry.Entity.Created = DateTimeOffset.UtcNow;
                logger.LogInformation("Updating the Created date on {entity}.", nameof(IAuditableEntity));
            }

            if (auditableEntry.State == EntityState.Modified)
            {
                auditableEntry.Entity.Modified = DateTimeOffset.UtcNow;
                logger.LogInformation("Updating the Modified date on {entity}.", nameof(IAuditableEntity));
            }
        }
        
        return base.SavingChangesAsync(eventData, result, cancellationToken);
    }
}