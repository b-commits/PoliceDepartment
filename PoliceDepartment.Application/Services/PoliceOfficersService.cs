using PoliceDepartment.Application.Commands;
using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Services;

public class PoliceOfficersService : IPoliceOfficerService
{
    private readonly IPoliceOfficerRepository _policeOfficerRepository;

    public PoliceOfficersService(IPoliceOfficerRepository policeOfficerRepository)
    {
        _policeOfficerRepository = policeOfficerRepository;
    }

    public async Task<IEnumerable<PoliceOfficer>> GetAll()
        => await _policeOfficerRepository.GetAll();

    public async Task<PoliceOfficer> GetByGuid(Guid id)
    {
        var officer = await _policeOfficerRepository.GetByGuid(id);
        
        if (officer is null)
        {
            throw new OfficerNotFoundException(id);
        }

        return officer;
    }
    
    public async Task Remove(DeletePoliceOfficerCommand command)
    {
        var officer = await _policeOfficerRepository.GetByGuid(command.Id);
        
        if (officer is null)
        {
            throw new OfficerNotFoundException(command.Id);
        }
        
        await _policeOfficerRepository.Remove(officer);
    }

    public async Task<Guid> Add(CreatePoliceOfficerCommand policeOfficer)
    {
        var existingOfficer = await _policeOfficerRepository.GetByBadgeNumber(policeOfficer.BadgeNumber);
        
        if (existingOfficer is not null)
        {
            throw new BadgeNumberAlreadyRegistered(policeOfficer.BadgeNumber.Value);
        }

        var newOfficer = new PoliceOfficer(policeOfficer.Id, policeOfficer.FirstName, policeOfficer.LastName,
            policeOfficer.BirthDate, policeOfficer.BadgeNumber);

        await _policeOfficerRepository.Add(newOfficer);

        return newOfficer.Id;
    }
    
    public async Task<bool> Update(PoliceOfficer policeOfficer, Guid id)
    {
        var existingOfficer = await _policeOfficerRepository.GetByGuid(id);
        
        if (existingOfficer is null)
        {
            throw new OfficerNotFoundException(policeOfficer.Id);
        }

        existingOfficer.BadgeNumber.Value = policeOfficer.BadgeNumber.Value;
        return true;
    }
}