using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;
using DynamoDbMapper.Sdk.Attributes;

namespace {{solution_name}}.Domain.Models.Identity;

[DynamoDBTable("User")]
public class User : Entity
{
    [JsonProperty("Name")]
    [DynamoDBProperty("Nome")]
    public string Nome { get; set; }

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
}