using CruderSimple.Core.ViewModels;
using {{solution_name}}.Domain.ViewModels.{{multitenant_name}};

namespace {{solution_name}}.Domain.ViewModels.Base;

public record {{multitenant_name}}EntityOutput(
    string Id, 
    string CreatedAt, 
    string UpdatedAt,
    string {{multitenant_name}}Id,
    {{multitenant_name}}Output {{multitenant_name}}) : OutputDto(Id, CreatedAt, UpdatedAt);