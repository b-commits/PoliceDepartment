using MediatR;
using PoliceDepartment.Application.Security;

namespace PoliceDepartment.Application.Handlers.SignIn;

public record SignInCommand(string username, string email) : IRequest<JwtDto>;