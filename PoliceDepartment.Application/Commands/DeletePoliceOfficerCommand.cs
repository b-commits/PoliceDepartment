using MediatR;

namespace PoliceDepartment.Application.Commands;

public record DeletePoliceOfficerCommand(Guid Id) : IRequest;