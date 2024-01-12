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

    public override BaseDto ConvertToOutput(IDictionary<string, bool> cached = null) 
    {
        if (cached is null)
            cached = new Dictionary<string, bool>();
        if (cached.ContainsKey(Id))
            return null;
        cached.Add(Id, true);

        return new {{multitenant_name}}Dto(
            Id, 
            CreatedAt, 
            UpdatedAt,
            Name
            /* ... */);
    }
}