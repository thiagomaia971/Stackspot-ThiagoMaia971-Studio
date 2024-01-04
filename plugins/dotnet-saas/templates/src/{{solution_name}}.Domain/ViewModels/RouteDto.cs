using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;
public class RouteDto : BaseDto
{
    public override string GetKey => Id;
    public override string GetValue => Name;

    public string Name { get; set; }
    public string Parent { get; set; }
    public string Icon { get; set; }
    public string Url { get; set; }
    public int Position { get; set; }
    public bool Visible { get; set; }    
    public string DependsOn { get; set; }

    public RouteDto() : base (null, DateTime.MinValue, null)
    {
    }

    public RouteDto(
        string id,
        DateTime createdAt, 
        DateTime? updatedAt,
        string name,
        string parent,
        string icon, 
        string url, 
        int position,
        bool visible,
        string dependsOn) : base (id, createdAt, updatedAt)
    {
        Name = name;
        Parent = parent;
        Icon = icon;
        Url = url;
        Position = position;
        Visible = visible;
        DependsOn = dependsOn;
    }
}
