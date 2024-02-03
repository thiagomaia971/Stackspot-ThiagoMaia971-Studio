using System.ComponentModel.DataAnnotations;
using CruderSimple.Core.Entities;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Attributes;
using CruderSimple.MySql.Entities;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.Attributes;
using Mapster;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

public abstract class {{multitenant_name}}Entity : Entity, ITenantEntity
{
    [MultiTenant]
    [StringLength(36)]
    public string {{multitenant_name}}Id { get; set; }
    
    [Include]
    [AutoDetach]
    public {{multitenant_name}} {{multitenant_name}} { get; set; }

    public override IEntity FromInput(BaseDto input) 
        => this.ParseWithContext<{{multitenant_name}}Entity, {{multitenant_name}}EntityDto>(input);

    public override BaseDto ConvertToOutput()
        => FromOutputBase<{{multitenant_name}}Entity, {{multitenant_name}}EntityDto>();
}