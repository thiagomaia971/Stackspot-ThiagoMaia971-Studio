using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels.{{multitenant_name}};

public record {{multitenant_name}}Output(
    string Id, 
    string CreatedAt, 
    string UpdatedAt,
    string Name
    /* ... */) : OutputDto(Id, CreatedAt, UpdatedAt);