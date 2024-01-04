using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;

public class CompanyEntityDto : BaseDto
{
    public override string GetKey => Id;
    public override string GetValue => Id;
    
    public string CompanyId { get; set; }
    public CompanyDto Company { get; set; }

    public CompanyEntityDto(
        string id,
        DateTime createdAt,
        DateTime? updatedAt,
        string companyId,
        CompanyDto company) : base (id, createdAt, updatedAt)
    {
        CompanyId = companyId;
        Company = company;
    }
}