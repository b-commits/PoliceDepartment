using PoliceDepartment.Application.Commands;
using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Services;

public class PoliceOfficersService : IPoliceOfficerService
{
    private readonly List<PoliceOfficer> Officers = new()
    {
        new PoliceOfficer(
            Guid.NewGuid(), "Sandy", "Lopez", 
            new DateOnly(1989, 9, 13), "#123-43-54"),
        new PoliceOfficer(
            Guid.NewGuid(), "Randall", "Emsden", 
            new DateOnly(1979, 12, 27), "#865-56-53")
    };

    public IEnumerable<PoliceOfficer> GetAll() 
        => Officers;

    public PoliceOfficer GetByGuid(Guid id)
    {
        var officer = Officers.SingleOrDefault(officer => officer.Id == id);
        
        if (officer is null)
        {
            throw new OfficerNotFoundException(id);
        }

        return officer;
    }
    
    public bool Remove(DeletePoliceOfficerCommand command)
    {
        var officer = Officers.SingleOrDefault(officer => officer.Id == command.Id);
        
        if (officer is null)
        {
            throw new OfficerNotFoundException(command.Id);
        }
        
        return Officers.Remove(officer);
    }

    public Guid Add(CreatePoliceOfficerCommand policeOfficer)
    {
        var officer = Officers.SingleOrDefault(officer => officer.BadgeNumber == policeOfficer.BadgeNumber);
        
        if (officer is null)
        {
            throw new BadgeNumberAlreadyRegistered(policeOfficer.BadgeNumber.Value);
        }

        var newOfficer = new PoliceOfficer(policeOfficer.Id, policeOfficer.FirstName, policeOfficer.LastName,
            policeOfficer.BirthDate, policeOfficer.BadgeNumber);

        return newOfficer.Id;
    }
    
    public bool Update(PoliceOfficer policeOfficer, Guid id)
    {
        var officer = Officers.SingleOrDefault(officer => officer.Id == id);
        
        if (officer is null)
        {
            throw new OfficerNotFoundException(policeOfficer.Id);
        }

        officer.BadgeNumber.Value = policeOfficer.BadgeNumber.Value;
        return true;
    }
}