namespace PoliceDepartment.Core.Entities;

public sealed class User(
    Guid id,
    string email,
    string username,
    string password,
    string role,
    DateTime createdAt)
{
    public Guid Id { get; private set; } = id;
    public string Email { get; private set; } = email;
    public string Username { get; private set; } = username; // TODO Refactor to value objects.
    public string Password { get; private set; } = password;
    public string Role { get; private set; } = role;
    public DateTime CreatedAt { get; private set; } = createdAt;
}