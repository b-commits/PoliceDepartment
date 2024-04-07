using MediatR;
using PoliceDepartment.Application.Security;

namespace PoliceDepartment.Application.Handlers.SignIn;

public record SignInCommand(string Email, string Password) : IRequest<JwtDto>;