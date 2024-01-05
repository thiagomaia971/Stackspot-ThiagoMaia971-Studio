using System.Text.Json.Serialization;
using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;

public class CompanyEntityDto : BaseDto
{
    #region Properties
    [JsonIgnore]
    public override string GetKey => Id;
    [JsonIgnore]
    public override string GetValue => Id;
    
    public string CompanyId { get; set; }
    public CompanyDto Company { get; set; }
    #endregion

    public CompanyEntityDto() : base ()
    {
    }

    public CompanyEntityDto(
        string id,
        DateTime createdAt,
        DateTime? updatedAt,
        string companyId) : base (id, createdAt, updatedAt)
    {
        CompanyId = companyId;
    }

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