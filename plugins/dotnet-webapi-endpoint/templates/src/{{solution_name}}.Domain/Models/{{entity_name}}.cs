using CruderSimple.Core.ViewModels;
using CruderSimple.{{database_name}}.Entities;
using {{solution_name}}.Domain.ViewModels.{{entity_name}}ViewModels;

namespace {{solution_name}}.Domain.Models;

public class {{entity_name}} : {%if is_multitenant == "True"%}TenantEntity{%else%}Entity{%endif%}
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
            UpdatedAt?.ToString("O")
            /* ... */);
}