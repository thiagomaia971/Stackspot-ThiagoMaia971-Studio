using Amazon.DynamoDBv2.DataModel;
using CruderSimple.Core.ViewModels;
using CruderSimple.DynamoDb.Entities;
using {{solution_name}}.Domain.ViewModels.{{entity_name}}ViewModels;
{%if is_multitenant == "True"%}
using {{solution_name}}.Domain.ViewModels.{{multitenant_name}}ViewModels;
{%endif%}

namespace {{solution_name}}.Domain.Models;

[DynamoDBTable("{{solution_name}}")]
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
            CreatedAt, 
            UpdatedAt
            /* ... */);
}