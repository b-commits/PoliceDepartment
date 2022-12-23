using PoliceDepartment.Application.Commands;
using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Application.Services;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Core.ValueObjects;

namespace PoliceDepartment.Test.Services;

public sealed class PoliceOfficerTests
{
    private readonly PoliceOfficersService _sut;
    private readonly IPoliceOfficerRepository _repository;
    
    public PoliceOfficerTests()
    {
        _repository = Substitute.For<IPoliceOfficerRepository>();
        _sut = new PoliceOfficersService(_repository);
    }

    [Fact]
    public void AddAsync_BadgeNumberAlreadyRegistered_ThrowsPoliceDepartmentException()
    {
        // Arrange
        const string repeatingBadge = "#-123-344-545";
        var command = new CreatePoliceOfficerCommand("Johnny", "Schmeichal", 
            repeatingBadge, new DateOnly(1995, 1, 18), Guid.Empty);
        _repository
            .GetByBadgeNumberAsync(Arg.Any<BadgeNumber>())
            .Returns(new PoliceOfficer(Guid.Empty, "Timotee", "Hirings", 
                new DateOnly(1995, 1, 18), repeatingBadge));
        
        // Act
        async Task Action() => await _sut.AddAsync(command);

        // Assert
        Assert.ThrowsAsync<BadgeNumberAlreadyRegistered>(Action);
    }
}