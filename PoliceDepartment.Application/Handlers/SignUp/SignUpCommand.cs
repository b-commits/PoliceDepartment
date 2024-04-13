using MediatR;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Application.Handlers.SignUp;

public record SignUpCommand(string Email, Username Username, string Password) : IRequest<User?>;