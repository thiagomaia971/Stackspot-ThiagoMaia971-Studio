using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
using CruderSimple.Core.Extensions;
using CruderSimple.MySql.Attributes;
using CruderSimple.Core.Entities;
using Mapster;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

public class UserRole : Entity
{
    [JsonProperty("RoleId")]
    public string RoleId { get; set; }

    [Include]
    [AutoDetach]
    public Role Role { get; set; }
    
    [JsonProperty("UserId")]
    public string UserId { get; set; }

    [Include]
    [AutoDetach]
    public User User { get; set; }

    public override IEntity FromInput(BaseDto input) 
        => this.ParseWithContext<UserRole, UserRoleDto>(input);

    public override BaseDto ConvertToOutput()
        => FromOutputBase<UserRole, UserRoleDto>();
}
