using Newtonsoft.Json;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
using CruderSimple.MySql.Attributes;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.Entities;
using CruderSimple.Core.Extensions;
using Mapster;
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

    public override IEntity FromInput(BaseDto input) 
        => this.ParseWithContext<Role, RoleDto>(input);

    public override BaseDto ConvertToOutput()
        => FromOutputBase<Role, RoleDto>();
}