using CruderSimple.Core.Entities;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
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
    {
        base.FromInput(input);
        var RouteDto = (RouteDto)input;
        Name = RouteDto.Name;
        Parent = RouteDto.Parent;
        Icon = RouteDto.Icon;
        Url = RouteDto.Url;
        Position = RouteDto.Position;
        Visible = RouteDto.Visible;
        DependsOn = RouteDto.DependsOn;
        return this;
    }

    public override BaseDto ConvertToOutput()
    {
        return new RouteDto(
            Id,
            CreatedAt,
            UpdatedAt,
            Name,
            Parent,
            Icon,
            Url,
            Position,
            Visible,
            DependsOn);
    }
}
