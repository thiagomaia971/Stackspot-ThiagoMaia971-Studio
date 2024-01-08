using System.Text.Json.Serialization;
using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;

public class {{multitenant_name}}EntityDto : BaseDto
{
    #region Properties
    [JsonIgnore]
    public override string GetKey => Id;
    [JsonIgnore]
    public override string GetValue => Id;
    
    public string {{multitenant_name}}Id { get; set; }
    public {{multitenant_name}}Dto {{multitenant_name}} { get; set; }
    #endregion

    public {{multitenant_name}}EntityDto() : base ()
    {
    }

    public {{multitenant_name}}EntityDto(
        string id,
        DateTime createdAt,
        DateTime? updatedAt,
        string {{multitenant_name|camelcase}}Id) : base (id, createdAt, updatedAt)
    {
        {{multitenant_name}}Id = {{multitenant_name|camelcase}}Id;
    }

    public {{multitenant_name}}EntityDto(
        string id,
        DateTime createdAt,
        DateTime? updatedAt,
        string {{multitenant_name|camelcase}}Id,
        {{multitenant_name}}Dto {{multitenant_name|camelcase}}) : base (id, createdAt, updatedAt)
    {
        {{multitenant_name}}Id = {{multitenant_name|camelcase}}Id;
        {{multitenant_name}} = {{multitenant_name|camelcase}};
    }
}