using System.Text.Json.Serialization;
using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;

public class CompanyDto : BaseDto
{
    #region Properties
    [JsonIgnore]
    public override string GetKey => Id;
    [JsonIgnore]
    public override string GetValue => Name;
    
    public string Name { get; set; }
    #endregion

    public CompanyDto() : base ()
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