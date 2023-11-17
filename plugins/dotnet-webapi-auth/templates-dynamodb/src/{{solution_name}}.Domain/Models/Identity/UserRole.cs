using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;

namespace {{solution_name}}.Domain.Models.Identity;

[DynamoDBTable("{{solution_name}}")]
public class UserRole : Entity
{
    [JsonProperty("RoleId")]
    [DynamoDBProperty("RoleId")]
    public string RoleId { get; set; }

    public UserRole()
    {
        
    }
}
