using System.Runtime.CompilerServices;
using LanguageExt.Common;
using NSubstitute;
using PoliceDepartment.Application.Exceptions;
using PoliceDepartment.Application.Handlers.CreatePoliceOfficer;
using PoliceDepartment.Application.Services;
using PoliceDepartment.Core.Entities;
using PoliceDepartment.Core.Repositories;
using PoliceDepartment.Core.ValueObjects;
using Xunit.Abstractions;

namespace PoliceDepartment.Test.Services;


public sealed class PoliceOfficersServiceTests
{
    private readonly ITestOutputHelper _testOutputHelper;
    private readonly PoliceOfficersService _sut;
    private readonly IPoliceOfficerRepository _repository;

    public PoliceOfficersServiceTests(ITestOutputHelper testOutputHelper)
    {
        _testOutputHelper = testOutputHelper;
        _repository = Substitute.For<IPoliceOfficerRepository>();
        _sut = new PoliceOfficersService(_repository);
    }

    // Moge mieć prywatny enum, poniewaz enum to tak naprawde statyczna klas
    // Default access modifier to zawsze najbardziej restrykcyjny,
    // czyli jezeli masz klase w klasie, to bedzie private, a w innym wypadku internal
    enum Pet
    {
        DOG, // 0 
        CAT = 2,
        BADGER = 3,
    }

    private Type doStuff<T>()
        => typeof(T);
    
    


        


    [Fact]
    public object Out_Parameters()
    {
        var myObject = new { A = 3 }; // anonymous object
        var myObjectType = myObject.GetType();
        var result = new Result<string>();


        return null;
    }


    [Fact]
    public void Enum_Behaviors()
    {
        // Parsowanie z out. PARSOWANIE ZAWSZE z tekstu:
        var c = int.TryParse("12", out var myInt);

        // Throws exception:
        // var myNum = int.Parse("");

        var myEnum = (Pet)4;

        var otherCast = (long)Pet.CAT;

        Console.WriteLine(myEnum);

        var stringified = myInt.ToString();

        // TryParse: zwraca bool jezeli dany string da sie sparsowac:
        var a = Enum.TryParse<Pet>("CAT", out var pet);
        
        // Casting, should be 2:
        var value = (long)pet;
        
        // Throws exception 
        // var myPet = Enum.Parse<Pet>("alligator");

        var petNames = Enum.GetNames<Pet>();

        var petNamesWithoutGeneric = Enum.GetNames(typeof(Pet));

        var valuesOfPet = Enum.GetValues<Pet>();

        var underlyingType = Enum.GetUnderlyingType(typeof(Pet));

        var typeOfEnum = pet.GetType();

        object inter = 3;
        
        var isDefined = Enum.IsDefined((Pet)2);
        var b = Enum.IsDefined<Pet>(Pet.CAT);

    }
    
    [Fact]
    public async void Various_Tests()
    {
        // 1. Żeby moc zrobic await wystarczy, ze zwrocony bedzie task
        
        static Task<IEnumerable<string>> doStuff()
        {
            IEnumerable<string> ids = new[] { "a", "b" };
            return Task.FromResult(ids);
        }

        // 2. Mapper nie zawsze jest praktyczny.
        // Nie nalezym mockowac mappera w testach tylko uzywac konkretniej implementacji.

        // Linq are just extension methods on IEnumerable:
        // You can't use select without awaiting first and putting this in parenthesis.
        // var stuff = await doStuff().Select(x => x.Length);
        
        // typof, gettype, enum isDefined, enum tryparse, enum parse
        
        // Enums are static nested classes because they define static member variables (the enum values), and this is disallowed for inner classes:
        var dog = (Pet)1;
        
        //
        //
        //
        //
        //
        // var array = stuff.ToArray();
        // var other = stuff.ToDictionary(stuff => stuff[0]);
        //
        //
        // var a = typeof(Guid);
        //
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
            .Returns(new PoliceOfficer(Guid.Empty, "Timotee", "Hiring", 
                new DateOnly(1995, 1, 18), repeatingBadge));
        
        // Act
        async Task Action() => await _sut.AddAsync(command);

        // Assert
        Assert.ThrowsAsync<BadgeNumberAlreadyRegisteredException>(Action);
    }
}