using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;
using CruderSimple.Core.ViewModels;
using CruderSimple.DynamoDb.Entities;

namespace {{solution_name}}.Domain.Models.Identity;

[DynamoDBTable("{{solution_name}}")]
public class Role : Entity
{
    [JsonProperty("Name")]
    [DynamoDBProperty("Name")]
    public string Name { get; set; }

    public override Entity FromInput(InputDto input)
    {
        throw new NotImplementedException();
    }

    public override OutputDto ToOutput()
    {
        throw new NotImplementedException();
    }
}