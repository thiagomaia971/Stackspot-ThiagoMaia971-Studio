using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Entities;
{%if is_multitenant == "True"%}
using CruderSimple.Core.Extensions;
using {{solution_name}}.Domain.Models.Identity;
{%endif%}
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models;

public class {{entity_name}} : {%if is_multitenant == "True"%}{{multitenant_name}}Entity{%else%}Entity{%endif%}
{
    #region Properties

    #endregion

    public override Entity FromInput(BaseDto input)
    {
        base.FromInput(input);
        var {{entity_name | camelcase}}Input = ({{entity_name}}Dto) input;
        /*
        ...
        */
        return this;
    }

    public override BaseDto ConvertToOutput() 
        => new {{entity_name}}Dto(
            Id, 
            CreatedAt, 
            UpdatedAt{%if is_multitenant == "True"%},
            {{multitenant_name}}Id,
            {{multitenant_name}}.ToOutput<{{multitenant_name}}Dto>()
{%endif%}           /* ... */);
}