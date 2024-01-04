using {{solution_name}}.Domain.ViewModels;
using {{solution_name}}.Domain.ViewModels.{{multitenant_name}};

namespace {{solution_name}}.Domain.ViewModels.{{entity_name}};

public record {{entity_name}}Output(
    string Id, 
    string CreatedAt, 
    string UpdatedAt,
    string {{multitenant_name}}Id,
    {{multitenant_name}}Output {{multitenant_name}}
    /* ... */) : {{multitenant_name}}EntityOutput(Id, CreatedAt, UpdatedAt, {{multitenant_name}}Id, {{multitenant_name}});