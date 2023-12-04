using CruderSimple.Core.ViewModels;
using CruderSimple.{{database_name}}.Entities;
using {{solution_name}}.Domain.ViewModels.{{multitenant_name}};

namespace {{solution_name}}.Domain.Models;

public class {{multitenant_name}} : Entity
{
    public string Name { get; set; }

    public override Entity FromInput(InputDto input)
    {
        base.FromInput(input);
        var {{multitenant_name | camelcase}}Input = ({{multitenant_name}}Input) input;
        Name = {{multitenant_name | camelcase}}Input.Name;
        /*
        ...
        */
        return this;
    }

    public override OutputDto ToOutput() 
        => new {{multitenant_name}}Output(
            Id, 
            CreatedAt.ToString("O"), 
            UpdatedAt?.ToString("O"),
            Name
            /* ... */);
}