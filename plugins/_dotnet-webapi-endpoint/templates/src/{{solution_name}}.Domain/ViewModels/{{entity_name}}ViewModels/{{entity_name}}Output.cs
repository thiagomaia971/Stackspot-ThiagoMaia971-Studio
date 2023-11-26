using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels.{{entity_name}}ViewModels;

public record {{entity_name}}Output(
    string Id, 
    string CreatedAt, 
    string UpdatedAt
    /* ... */) : OutputDto(Id, CreatedAt, UpdatedAt);