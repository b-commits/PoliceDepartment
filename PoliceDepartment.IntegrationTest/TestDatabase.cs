using PoliceDepartment.Infrastructure.DAL;

namespace PoliceDepartment.IntegrationTest;

internal sealed class TestDatabase : IDisposable
{
    private PoliceDepartmentDbContext Context { get; }

    public TestDatabase(PoliceDepartmentDbContext dbContext)
    {
        // var options = new OptionsProvider().GetConnectionString()
    }

    public void Dispose()
    {
        Context.Dispose();
    }
}