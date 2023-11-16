using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;

namespace {{solution_name}}.Domain.Models.Identity;

[DynamoDBTable("Role")]
public class Role : Entity
{
    [JsonProperty("Name")]
    [DynamoDBProperty("Name")]
    public string Name { get; set; }
}