using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Application.Handlers.CreatePoliceOfficer;
using PoliceDepartment.Application.Handlers.DeletePoliceOfficer;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;

namespace PoliceDepartment.Application.Services;

// TODO This is deprecated and can probably be removed
public class PoliceOfficersService(IPoliceOfficerRepository policeOfficerRepository) : IPoliceOfficerService
{
    public Task<IEnumerable<PoliceOfficer>> GetAllAsync()
    {
        return policeOfficerRepository.GetAllAsync();
    }

    public async Task<PoliceOfficer> GetByGuidAsync(Guid id)
    {
        var officer = await policeOfficerRepository.GetByGuidAsync(id);
        
        if (officer is null)
            throw new OfficerNotFoundException(id);

        return officer;
    }
    
    public async Task RemoveAsync(DeletePoliceOfficerCommand command)
    {
        var officer = await policeOfficerRepository.GetByGuidAsync(command.Id);
        
        if (officer is null)
            throw new OfficerNotFoundException(command.Id);
        
        await policeOfficerRepository.RemoveAsync(officer.Id);
    }

    public async Task<Guid> AddAsync(CreatePoliceOfficerCommand policeOfficer)
    {
        var existingOfficer = await policeOfficerRepository.GetByBadgeNumberAsync(policeOfficer.BadgeNumber);
        
        if (existingOfficer is not null)
            throw new BadgeNumberAlreadyRegisteredException(policeOfficer.BadgeNumber.Value);

        var newOfficer = new PoliceOfficer(policeOfficer.Id, policeOfficer.FirstName, policeOfficer.LastName,
            policeOfficer.BirthDate, policeOfficer.BadgeNumber);

        await policeOfficerRepository.AddAsync(newOfficer);

        return newOfficer.Id;
    }
    
    public async Task<bool> Update(PoliceOfficer policeOfficer, Guid id)
    {
        var existingOfficer = await policeOfficerRepository.GetByGuidAsync(id);
        
        if (existingOfficer is null)
            throw new OfficerNotFoundException(policeOfficer.Id);
        
        existingOfficer.BadgeNumber.Value = policeOfficer.BadgeNumber.Value;
        return true;
    }
}