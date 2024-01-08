using System.Text.Json.Serialization;
namespace {{solution_name}}.Domain.ViewModels;

public class {{entity_name}}Dto : {%if is_multitenant == "True"%}{{multitenant_name}}EntityDto{%else%}BaseDto{%endif%}
{
    #region Properties

    [JsonIgnore]
    public override string GetKey => Id;
    [JsonIgnore]
    public override string GetValue => Id;

    #endregion

    public {{entity_name}}Dto()
    {
    }

    public {{entity_name}}Dto(
        string id,
        DateTime createdAt, 
        DateTime? updatedAt{%if is_multitenant == "True"%},
        string {{multitenant_name}}Id,
        {{multitenant_name}}Dto {{multitenant_name}}
{%endif%}           /* ... */) : base(id, createdAt, updatedAt{%if is_multitenant == "True"%},{{multitenant_name}}Id, {{multitenant_name}}{%endif%})
    {
    }
}