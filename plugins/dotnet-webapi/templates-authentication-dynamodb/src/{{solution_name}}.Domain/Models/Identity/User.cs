using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;
using CruderSimple.Core.ViewModels;
using CruderSimple.Core.Extensions;
using CruderSimple.DynamoDb.Attributes;
using CruderSimple.DynamoDb.Entities;
using {{solution_name}}.Domain.ViewModelsViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

[DynamoDBTable("{{solution_name}}")]
public class User : Entity
{
    [JsonProperty("Name")]
    [DynamoDBProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("EmailConfirmed")]
    [DynamoDBProperty("EmailConfirmed")]
    public bool EmailConfirmed { get; set; }

    [JsonProperty("PasswordHash")]
    [DynamoDBProperty("PasswordHash")]
    public string PasswordHash { get; set; }

    [JsonProperty("PhoneNumber")]
    [DynamoDBProperty("PhoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonProperty("PhoneNumberConfirmed")]
    [DynamoDBProperty("PhoneNumberConfirmed")]
    public bool PhoneNumberConfirmed { get; set; }

    [JsonProperty("TwoFactorEnabled")]
    [DynamoDBProperty("TwoFactorEnabled")]
    public bool TwoFactorEnabled { get; set; }

    [DynamoDBIgnore]
    [DynamoDbInner(typeof(UserRole))]
    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();

    public override Entity FromInput(InputDto input)
    {
        var UserDto = (UserDto)input;
        Id = UserDto.Id;
        PrimaryKey = UserDto.Email;
        Name = UserDto.Name;
        PhoneNumber = UserDto.PhoneNumber;
        Roles = Roles?.FromInput(UserDto.Roles);
        
        return this;
    }

    public override OutputDto ToOutput()
    {
        return new UserOutput(
            Id,
            CreatedAt,
            UpdatedAt,
            PrimaryKey,
            Name,
            EmailConfirmed,
            PhoneNumber,
            PhoneNumberConfirmed,
            TwoFactorEnabled,
            Roles.ToOutput<UserRole, UserRoleOutput>()
        );
    }
}