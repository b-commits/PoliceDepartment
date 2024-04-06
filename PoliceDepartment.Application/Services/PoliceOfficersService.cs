using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Application.Handlers.CreatePoliceOfficer;
using PoliceDepartment.Application.Handlers.DeletePoliceOfficer;
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

    public Task<IEnumerable<PoliceOfficer>> GetAllAsync()
    {
        return _policeOfficerRepository.GetAllAsync();
    }

    public async Task<PoliceOfficer> GetByGuidAsync(Guid id)
    {
        var officer = await _policeOfficerRepository.GetByGuidAsync(id);
        
        if (officer is null)
            throw new OfficerNotFoundException(id);

        return officer;
    }
    
    public async Task RemoveAsync(DeletePoliceOfficerCommand command)
    {
        var officer = await _policeOfficerRepository.GetByGuidAsync(command.Id);
        
        if (officer is null)
            throw new OfficerNotFoundException(command.Id);
        
        await _policeOfficerRepository.RemoveAsync(officer.Id);
    }

    public async Task<Guid> AddAsync(CreatePoliceOfficerCommand policeOfficer)
    {
        var existingOfficer = await _policeOfficerRepository.GetByBadgeNumberAsync(policeOfficer.BadgeNumber);
        
        if (existingOfficer is not null)
            throw new BadgeNumberAlreadyRegistered(policeOfficer.BadgeNumber.Value);

        var newOfficer = new PoliceOfficer(policeOfficer.Id, policeOfficer.FirstName, policeOfficer.LastName,
            policeOfficer.BirthDate, policeOfficer.BadgeNumber);

        await _policeOfficerRepository.AddAsync(newOfficer);

        return newOfficer.Id;
    }
    
    public async Task<bool> Update(PoliceOfficer policeOfficer, Guid id)
    {
        var existingOfficer = await _policeOfficerRepository.GetByGuidAsync(id);
        
        if (existingOfficer is null)
            throw new OfficerNotFoundException(policeOfficer.Id);
        
        existingOfficer.BadgeNumber.Value = policeOfficer.BadgeNumber.Value;
        return true;
    }
}