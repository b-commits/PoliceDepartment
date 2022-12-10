using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Core.Entities;

namespace PoliceDepartment.Application.Services;

public class PoliceOfficersService
{
    private readonly List<PoliceOfficer> Officers = new()
    {
        new PoliceOfficer(Guid.NewGuid(), "Sandy", "Lopez", new DateOnly(1989, 9, 13), "#123-43-54"),
        new PoliceOfficer(Guid.NewGuid(), "Randall", "Emsden", new DateOnly(1979, 12, 27), "#865-56-53")
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
    
    public bool Remove(Guid id)
    {
        var officer = Officers.SingleOrDefault(officer => officer.Id == id);
        
        if (officer is null)
        {
            throw new OfficerNotFoundException(id);
        }
        
        return Officers.Remove(officer);
    }

    public Guid Add(PoliceOfficer policeOfficer)
    {
        var officer = Officers.SingleOrDefault(officer => officer.Id == policeOfficer.Id);
        
        if (officer is null)
        {
            throw new OfficerAlreadyExists(policeOfficer.Id);
        }
        
        policeOfficer.Id = Guid.NewGuid();
        Officers.Add(policeOfficer);

        return policeOfficer.Id;
    }
    
    public void Update(PoliceOfficer policeOfficer, Guid id)
    {
        var officer = Officers.SingleOrDefault(officer => officer.Id == id);
        
        if (officer is null)
        {
            throw new OfficerNotFoundException(policeOfficer.Id);
        }

        officer.BadgeNumber = policeOfficer.BadgeNumber;
    }
    
    
    
    









}