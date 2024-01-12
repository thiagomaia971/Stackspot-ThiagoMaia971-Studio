using System.ComponentModel.DataAnnotations;
using CruderSimple.Core.Entities;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Attributes;
using CruderSimple.MySql.Entities;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.Attributes;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

public abstract class {{multitenant_name}}Entity : Entity, ITenantEntity
{
    [MultiTenant]
    [StringLength(36)]
    public string {{multitenant_name}}Id { get; set; }
    
    [Include]
    public {{multitenant_name}} {{multitenant_name}} { get; set; }

    public override IEntity FromInput(BaseDto input)
    {
        base.FromInput(input);
        var {{multitenant_name}}Dto = ({{multitenant_name}}EntityDto)input;
        {{multitenant_name}}Id = {{multitenant_name}}Dto.{{multitenant_name}}Id;
        
        return this;
    }

    public override BaseDto ConvertToOutput(IDictionary<string, bool> cached = null)
    {
        if (cached is null)
            cached = new Dictionary<string, bool>();
        if (cached.ContainsKey(Id))
            return null;
        cached.Add(Id, true);
        
        return new {{multitenant_name}}EntityDto(
            Id,
            CreatedAt,
            UpdatedAt,
            {{multitenant_name}}Id,
            {{multitenant_name}}?.ToOutput<{{multitenant_name}}Dto>(cached));
    }
}