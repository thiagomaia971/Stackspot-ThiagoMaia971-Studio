using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;

public class PermissionDto : BaseDto
{
    public override string GetKey => Id;
    public override string GetValue => Role is null || Route is null ? null : $"{Role.Name}-{Route.Name}";

    public string RoleId { get; set; }
    public RoleDto Role { get; set; }
    public string RouteId { get; set; }
    public RouteDto Route { get; set; }
    public bool IsRead { get; set; }
    public bool IsWrite { get; set; }


    public PermissionDto() : base(null, DateTime.MinValue, null)
    {
        
    }

    public PermissionDto (
        string id,
        DateTime createdAt, 
        DateTime? updatedAt, 
        string roleId,
        RoleDto role,
        string routeId,
        RouteDto route,
        bool isRead,
        bool isWrite) : base(id, createdAt, updatedAt)
    {
        RoleId = roleId;
        RouteId = routeId;
        Role = role;
        Route = route;
        IsRead = isRead;
        IsWrite = isWrite;
    }
}