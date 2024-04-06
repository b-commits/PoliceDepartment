using MediatR;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Application.Handlers.SignUp;

public record SignUpCommand(Guid UserId, string Email, Username Username, string Password, string Role) : IRequest;