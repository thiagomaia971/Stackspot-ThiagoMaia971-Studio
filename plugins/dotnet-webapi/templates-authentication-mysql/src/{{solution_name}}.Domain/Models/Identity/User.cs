using Newtonsoft.Json;
using CruderSimple.Core.ViewModels;
using CruderSimple.Core.Extensions;
using CruderSimple.MySql.Entities;
using {{solution_name}}.Domain.ViewModels.UserViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

public class User : Entity
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

    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();

    public override Entity FromInput(InputDto input)
    {
        base.FromInput(input);
        var userInput = (UserInput)input;
        Email = userInput.Email;
        Name = userInput.Name;
        PhoneNumber = userInput.PhoneNumber;
        Roles = Roles?.FromInput(userInput.Roles);
        
        return this;
    }

    public override OutputDto ToOutput()
    {
        return new UserOutput(
            Id,
            CreatedAt.ToString("O"),
            UpdatedAt?.ToString("O"),
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