using PoliceDepartment.Core.Primitives;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Core.Entities;

public sealed class User(
    Guid id,
    string email,
    Username username,
    string password,
    string role,
    DateTime createdAt) : IAuditableEntity
{
    public Guid Id { get; private set; } = id;
    public string Email { get; private set; } = email;
    public Username Username { get; private set; } = username; 
    public string Password { get; private set; } = password;
    public string Role { get; private set; } = role;
    public DateTime CreatedAt { get; private set; } = createdAt;
    public DateTimeOffset Created { get; set; }
    public DateTimeOffset Modified { get; set; }
}