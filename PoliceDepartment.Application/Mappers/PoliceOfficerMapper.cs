using PoliceDepartment.Application.Handlers.CreatePoliceOfficer;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Mappers;

internal static class PoliceOfficerMapper
{
    public static PoliceOfficer Map(CreatePoliceOfficerCommand createPoliceOfficerCommand)
    {
        return new PoliceOfficer(createPoliceOfficerCommand.Id, 
            createPoliceOfficerCommand.FirstName, 
            createPoliceOfficerCommand.LastName, 
            createPoliceOfficerCommand.BirthDate,
            createPoliceOfficerCommand.BadgeNumber);
    }
}