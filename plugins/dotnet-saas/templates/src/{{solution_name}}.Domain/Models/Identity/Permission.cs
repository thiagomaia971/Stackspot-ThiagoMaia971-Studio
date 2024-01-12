using CruderSimple.Core.Entities;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Attributes;
using CruderSimple.MySql.Entities;
using CruderSimple.Core.Extensions;
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
    {
        base.FromInput(input);
        var permissionInput = (PermissionDto)input;
        RoleId = permissionInput.RoleId;
        RouteId = permissionInput.RouteId;
        IsRead = permissionInput.IsRead;
        IsWrite = permissionInput.IsWrite;
        return this;
    }

    public override BaseDto ConvertToOutput(IDictionary<string, bool> cached = null)
    {
        if (cached is null)
            cached = new Dictionary<string, bool>();
        if (cached.ContainsKey(Id))
            return null;
        cached.Add(Id, true);
        
        return new PermissionDto(
            Id,
            CreatedAt,
            UpdatedAt,
            RoleId,
            null, // Role?.ToOutput<RoleDto>(),
            RouteId,
            Route?.ToOutput<RouteDto>(cached),
            IsRead,
            IsWrite);
    }
}
