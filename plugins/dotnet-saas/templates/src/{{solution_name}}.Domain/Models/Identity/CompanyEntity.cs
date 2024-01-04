using System.ComponentModel.DataAnnotations;
using CruderSimple.Core.Entities;
using CruderSimple.Core.ViewModels;
using CruderSimple.MySql.Attributes;
using CruderSimple.MySql.Entities;
using CruderSimple.Core.Extensions;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

public abstract class CompanyEntity : Entity, ITenantEntity
{
    [MultiTenant]
    [StringLength(36)]
    public string CompanyId { get; set; }
    
    [Include]
    [AutoDetach]
    public Company Company { get; set; }

    public override IEntity FromInput(BaseDto input)
    {
        base.FromInput(input);
        var CompanyDto = (CompanyEntityDto)input;
        CompanyId = CompanyDto.CompanyId;
        
        return this;
    }

    public override BaseDto ConvertToOutput()
    {
        return new CompanyEntityDto(
            Id,
            CreatedAt,
            UpdatedAt,
            CompanyId,
            Company?.ToOutput<CompanyDto>());
    }
}