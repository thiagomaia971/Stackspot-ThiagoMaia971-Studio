using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;

namespace Test.Domain.Models.Identity;

[DynamoDBTable("Test")]
public class UserRole : Entity
{
    [JsonProperty("RoleId")]
    [DynamoDBProperty("RoleId")]
    public string RoleId { get; set; }

    public UserRole()
    {

    }
}
