using MediatR;

namespace PoliceDepartment.Application.Handlers.SignUp;

public record SignUpCommand(Guid UserId, string Email, string Username, string Password, string Role) : IRequest;