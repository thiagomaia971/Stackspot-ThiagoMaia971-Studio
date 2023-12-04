using Newtonsoft.Json;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
using {{solution_name}}.Domain.ViewModels.User;

namespace {{solution_name}}.Domain.Models.Identity;

public class UserRole : Entity
{
    [JsonProperty("RoleId")]
    public string RoleId { get; set; }

    public override Entity FromInput(InputDto input)
    {
        base.FromInput(input);
        var userRoleInput = (UserRoleInput)input;
        RoleId = userRoleInput.RoleId;
        return this;
    }

    public override OutputDto ToOutput()
    {
        return new UserRoleOutput(
            Id,
            CreatedAt.ToString("O"),
            UpdatedAt?.ToString("O"),
            RoleId);
    }
}
