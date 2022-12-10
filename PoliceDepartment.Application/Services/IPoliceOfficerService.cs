using PoliceDepartment.Application.Commands;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Services;

public interface IPoliceOfficerService
{
    IEnumerable<PoliceOfficer> GetAll();
    PoliceOfficer GetByGuid(Guid id);
    Guid Add(CreatePoliceOfficerCommand command);
    bool Remove(DeletePoliceOfficerCommand command);
}