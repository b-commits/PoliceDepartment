namespace PoliceDepartment.Application.Security;

public interface IAuthenticator
{
    JwtDto CreateToken(string email, string role);
}

public class JwtDto
{
    public string AccessToken { get; set; }
}