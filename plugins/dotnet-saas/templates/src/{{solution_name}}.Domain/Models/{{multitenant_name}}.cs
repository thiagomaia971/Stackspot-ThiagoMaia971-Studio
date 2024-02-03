using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models;

public class {{multitenant_name}} : Entity
{
    public string Name { get; set; }

    public override IEntity FromInput(BaseDto input) 
        => this.ParseWithContext<{{multitenant_name}}, {{multitenant_name}}Dto>(input);

    public override BaseDto ConvertToOutput()
        => FromOutputBase<{{multitenant_name}}, {{multitenant_name}}Dto>();
}