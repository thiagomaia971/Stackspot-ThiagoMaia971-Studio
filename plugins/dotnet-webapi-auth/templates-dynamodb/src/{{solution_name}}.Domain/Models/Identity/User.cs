using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;
using CruderSimple.Core.ViewModels;
using CruderSimple.DynamoDb.Attributes;
using CruderSimple.DynamoDb.Entities;

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
    public List<UserRole> Roles { get; set; }

    public override Entity FromInput(InputDto input)
    {
        throw new NotImplementedException();
    }

    public override OutputDto ToOutput()
    {
        throw new NotImplementedException();
    }
}