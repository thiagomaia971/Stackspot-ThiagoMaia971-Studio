using CruderSimple.Core.Entities;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
using Mapster;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

public class Route : Entity
{
    public string Name { get; set; }
    public string Parent { get; set; }
    public string Icon { get; set; }
    public string Url { get; set; }
    public int Position { get; set; }
    public bool Visible { get; set; }
    public string? DependsOn { get; set; }

    public override IEntity FromInput(BaseDto input) 
        => this.ParseWithContext<Route, RouteDto>(input);

    public override BaseDto ConvertToOutput()
        => FromOutputBase<Route, RouteDto>();
}
