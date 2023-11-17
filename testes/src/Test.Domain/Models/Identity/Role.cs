using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;

namespace Test.Domain.Models.Identity;

[DynamoDBTable("Test")]
public class Role : Entity
{
    [JsonProperty("Name")]
    [DynamoDBProperty("Name")]
    public string Name { get; set; }
}