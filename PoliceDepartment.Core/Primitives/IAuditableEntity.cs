namespace PoliceDepartment.Core.Primitives;

public interface IAuditableEntity
{
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Modified { get; set; }
}