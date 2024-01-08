using System.Text.Json.Serialization;
using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;

public class {{multitenant_name}}Dto : BaseDto
{
    #region Properties
    [JsonIgnore]
    public override string GetKey => Id;
    [JsonIgnore]
    public override string GetValue => Name;
    
    public string Name { get; set; }
    #endregion

    public {{multitenant_name}}Dto() : base ()
    {
    }

    public {{multitenant_name}}Dto(
        string id, 
        DateTime createdAt, 
        DateTime? updatedAt,
        string name
        /* ... */) : base(id, createdAt, updatedAt)
    {
        Name = name;
    }
};