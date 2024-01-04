using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models;

public class Company : Entity
{
    public string Name { get; set; }

    public override Entity FromInput(BaseDto input)
    {
        base.FromInput(input);
        var CompanyDto = (CompanyDto) input;
        Name = CompanyDto.Name;
        /*
        ...
        */
        return this;
    }

    public override BaseDto ConvertToOutput() 
        => new CompanyDto(
            Id, 
            CreatedAt, 
            UpdatedAt,
            Name
            /* ... */);
}