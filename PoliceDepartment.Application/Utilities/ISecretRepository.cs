namespace PoliceDepartment.Application.Utilities;

public interface ISecretRepository
{
    Task<string> Get();
    Task Set(string secret);
}