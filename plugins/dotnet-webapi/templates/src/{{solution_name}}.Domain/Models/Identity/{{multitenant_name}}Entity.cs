using System.ComponentModel.DataAnnotations;
using CruderSimple.Core.Entities;
using CruderSimple.Core.ViewModels;
using CruderSimple.Core.Extensions;
using CruderSimple.MySql.Attributes;
using CruderSimple.MySql.Entities;
using {{solution_name}}.Domain.ViewModels;
using {{solution_name}}.Domain.ViewModels.{{multitenant_name}};

namespace {{solution_name}}.Domain.Models.Identity;

public abstract class {{multitenant_name}}Entity : Entity, ITenantEntity
{
    [StringLength(36)]
    public string {{multitenant_name}}Id { get; set; }
    [IncludeAttribute]
    public {{multitenant_name}} {{multitenant_name}} { get; set; }

    public override IEntity FromInput(InputDto input)
    {
        base.FromInput(input);
        var {{multitenant_name|camelcase}}Input = ({{multitenant_name}}EntityInput)input;
        {{multitenant_name}}Id = {{multitenant_name|camelcase}}Input.{{multitenant_name}}Id;
        
        return this;
    }

    public override OutputDto ToOutput()
    {
        return new {{multitenant_name}}EntityOutput(
            Id,
            CreatedAt.ToString("O"),
            UpdatedAt?.ToString("O"),
            {{multitenant_name}}Id,
            {{multitenant_name}}?.ToOutput<{{multitenant_name}}Output>());
    }
}