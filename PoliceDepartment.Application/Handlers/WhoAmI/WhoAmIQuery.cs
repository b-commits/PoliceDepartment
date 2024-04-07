using MediatR;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Handlers.WhoAmI;

public sealed record WhoAmIQuery() : IRequest<User?>;