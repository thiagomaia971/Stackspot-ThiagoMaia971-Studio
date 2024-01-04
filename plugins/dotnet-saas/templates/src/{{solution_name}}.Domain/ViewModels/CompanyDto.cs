using System.Text.Json.Serialization;
using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;

public class CompanyDto : BaseDto
{
    public override string GetKey => Id;
    public override string GetValue => Name;
    
    public string Name { get; set; }

    public CompanyDto() : base (null, DateTime.MinValue, null)
    {
    }

    public CompanyDto(
        string id, 
        DateTime createdAt, 
        DateTime? updatedAt,
        string name
        /* ... */) : base(id, createdAt, updatedAt)
    {
        Name = name;
    }
};