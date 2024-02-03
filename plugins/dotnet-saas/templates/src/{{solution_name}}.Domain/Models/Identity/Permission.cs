using CruderSimple.Core.Entities;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Attributes;
using CruderSimple.MySql.Entities;
using CruderSimple.Core.Extensions;
using Mapster;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

public class Permission : Entity
{
    public string RoleId { get; set; }
    public string RouteId { get; set; }
    public bool IsRead { get; set; }
    public bool IsWrite { get; set; }

    [Include]
    [AutoDetach]
    public Role Role { get; set; }
    
    [Include]
    [AutoDetach]
    public Route Route { get; set; }

    public override IEntity FromInput(BaseDto input)
        => this.ParseWithContext<Permission, PermissionDto>(input);

    public override BaseDto ConvertToOutput()
        => FromOutputBase<Permission, PermissionDto>();
}
