using MediatR;

namespace PoliceDepartment.Application.Handlers.DeletePoliceOfficer;

public record DeletePoliceOfficerCommand(Guid Id) : IRequest;