using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models;

public class {{multitenant_name}} : Entity
{
    public string Name { get; set; }

    public override Entity FromInput(BaseDto input)
    {
        base.FromInput(input);
        var {{multitenant_name}}Dto = ({{multitenant_name}}Dto) input;
        Name = {{multitenant_name}}Dto.Name;
        /*
        ...
        */
        return this;
    }

    public override BaseDto ConvertToOutput() 
        => new {{multitenant_name}}Dto(
            Id, 
            CreatedAt, 
            UpdatedAt,
            Name
            /* ... */);
}