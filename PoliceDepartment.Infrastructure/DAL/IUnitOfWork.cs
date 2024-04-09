using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace PoliceDepartment.Infrastructure.DAL;

internal interface IUnitOfWork
{
    Task ExecuteAsync(Func<Task> action);
}

internal sealed class MySqlUnitOfWork(
    DbContext dbContext, 
    ILogger<MySqlUnitOfWork> logger)
    : IUnitOfWork
{
    public async Task ExecuteAsync(Func<Task> action)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        try
        {
            await action.Invoke();
            await dbContext.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            logger.LogError("Error processing transaction {exMessage}", 
                ex.Message);
            throw;
        }
    }
}



