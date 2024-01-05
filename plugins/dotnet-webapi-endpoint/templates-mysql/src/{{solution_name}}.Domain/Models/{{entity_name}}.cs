using CruderSimple.Core.ViewModels;
using CruderSimple.{{database_name}}.Entities;
{%if is_multitenant == "True"%}
using CruderSimple.Core.Extensions;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Domain.ViewModels.{{multitenant_name}};
{%endif%}
using {{solution_name}}.Domain.ViewModels.{{entity_name}};

namespace {{solution_name}}.Domain.Models;

public class {{entity_name}} : {%if is_multitenant == "True"%}{{multitenant_name}}Entity{%else%}Entity{%endif%}
{

    public override Entity FromInput(InputDto input)
    {
        base.FromInput(input);
        var {{entity_name | camelcase}}Input = ({{entity_name}}Input) input;
        /*
        ...
        */
        return this;
    }

    public override OutputDto ToOutput() 
        => new {{entity_name}}Output(
            Id, 
            CreatedAt.ToString("O"), 
            UpdatedAt?.ToString("O"){%if is_multitenant == "True"%},
            {{multitenant_name}}Id,
            {{multitenant_name}}.ToOutput<{{multitenant_name}}Output>()
{%endif%}           /* ... */);
}