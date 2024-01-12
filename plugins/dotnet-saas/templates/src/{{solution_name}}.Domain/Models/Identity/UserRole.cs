using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
using CruderSimple.Core.Extensions;
using CruderSimple.MySql.Attributes;
using CruderSimple.Core.Entities;
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

    public override Entity FromInput(BaseDto input)
    {
        base.FromInput(input);
        var userRoleDto = (UserRoleDto)input;
        RoleId = userRoleDto.RoleId;
        UserId = userRoleDto.UserId;
        return this;
    }

    public override BaseDto ConvertToOutput(IDictionary<string, bool> cached = null)
    {
        if (cached is null)
            cached = new Dictionary<string, bool>();
        if (cached.ContainsKey(Id))
            return null;
        cached.Add(Id, true);

        return new UserRoleDto(
            Id,
            CreatedAt,
            UpdatedAt,
            RoleId,
            Role?.ToOutput<RoleDto>(),
            UserId,
            User?.ToOutput<UserDto>());
    }
}
