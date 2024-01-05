using CruderSimple.Core.ViewModels;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.ViewModels.{{entity_name}};

public record {{entity_name}}Input(
    string Id,
    string {{multitenant_name}}Id
    /* ... */) : {{multitenant_name}}EntityInput(Id, {{multitenant_name}}Id);