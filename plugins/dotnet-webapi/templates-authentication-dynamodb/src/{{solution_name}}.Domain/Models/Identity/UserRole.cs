using Newtonsoft.Json;
using Amazon.DynamoDBv2.DataModel;
using CruderSimple.Core.ViewModels;
using CruderSimple.DynamoDb.Entities;
using {{solution_name}}.Domain.ViewModelsViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

[DynamoDBTable("{{solution_name}}")]
public class UserRole : Entity
{
    [JsonProperty("RoleId")]
    [DynamoDBProperty("RoleId")]
    public string RoleId { get; set; }

    public override Entity FromInput(InputDto input)
    {
        var userRoleDto = (UserRoleDto)input;
        Id = userRoleDto.Id;
        RoleId = userRoleDto.RoleId;
        return this;
    }

    public override OutputDto ToOutput()
    {
        return new UserRoleOutput(
            Id,
            CreatedAt,
            UpdatedAt,
            RoleId);
    }
}
