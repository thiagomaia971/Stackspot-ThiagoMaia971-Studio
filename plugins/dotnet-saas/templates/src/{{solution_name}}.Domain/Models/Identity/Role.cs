using Newtonsoft.Json;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
using CruderSimple.MySql.Attributes;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.Entities;
using CruderSimple.Core.Extensions;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

public class Role : {{multitenant_name}}Entity
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [Include] 
    public IEnumerable<Permission> Permissions { get; set; } = new List<Permission>();

    [AutoDetach]
    public IEnumerable<UserRole> Roles { get; set; }

    // [AutoDetach]
    // public IEnumerable<User> Users { get; set; }

    public override Entity FromInput(BaseDto input)
    {
        base.FromInput(input);
        var RoleDto = (RoleDto)input;
        Name = RoleDto.Name;
        Permissions = Permissions?.FromInput(RoleDto.Permissions.ToList());
        return this;
    }

    public override BaseDto ConvertToOutput()
    {
        return new RoleDto(
            Id,
            CreatedAt,
            UpdatedAt,
            {{multitenant_name}}Id,
            Name,
            Permissions?.ToOutput<Permission, PermissionDto>());
    }
}