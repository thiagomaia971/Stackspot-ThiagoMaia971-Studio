using Newtonsoft.Json;
using CruderSimple.Core.ViewModels;
using CruderSimple.Core.Extensions;
using CruderSimple.MySql.Entities;
using CruderSimple.MySql.Attributes;
using {{solution_name}}.Domain.ViewModels;
using {{solution_name}}.Domain.ViewModels.{{multitenant_name}};

namespace {{solution_name}}.Domain.Models.Identity;

public class User : {{multitenant_name}}Entity
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Email")]
    public string Email { get; set; }

    [JsonProperty("EmailConfirmed")]
    public bool EmailConfirmed { get; set; }

    [JsonProperty("PasswordHash")]
    public string PasswordHash { get; set; }

    [JsonProperty("PhoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonProperty("PhoneNumberConfirmed")]
    public bool PhoneNumberConfirmed { get; set; }

    [JsonProperty("TwoFactorEnabled")]
    public bool TwoFactorEnabled { get; set; }

    [IncludeAttribute]
    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();

    public override Entity FromInput(InputDto input)
    {
        base.FromInput(input);
        var UserDto = (UserDto)input;
        Email = UserDto.Email;
        Name = UserDto.Name;
        PhoneNumber = UserDto.PhoneNumber;
        Roles = Roles?.FromInput(UserDto.Roles);
        
        return this;
    }

    public override OutputDto ToOutput()
    {
        return new UserOutput(
            Id,
            CreatedAt.ToString("O"),
            UpdatedAt?.ToString("O"),
            {{multitenant_name}}Id,
            {{multitenant_name}}.ToOutput<{{multitenant_name}}Output>(),
            Email,
            Name,
            EmailConfirmed,
            PhoneNumber,
            PhoneNumberConfirmed,
            TwoFactorEnabled,
            Roles.ToOutput<UserRole, UserRoleOutput>()
        );
    }

    public override string GetPrimaryKey() => Email;
}