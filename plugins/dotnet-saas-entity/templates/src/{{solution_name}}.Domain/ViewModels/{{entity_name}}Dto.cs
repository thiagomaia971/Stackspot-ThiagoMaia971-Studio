using System.Text.Json.Serialization;
namespace {{solution_name}}.Domain.ViewModels;

public class {{entity_name}}Dto : {%if is_multitenant == "True"%}CompanyEntityDto{%else%}BaseDto{%endif%}
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
        string companyId,
        CompanyDto company
{%endif%}           /* ... */) : base(id, createdAt, updatedAt{%if is_multitenant == "True"%},companyId, company{%endif%})
    {
    }
}