using CruderSimple.Core.ViewModels;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.ViewModels.{{entity_name}};

public record {{entity_name}}Input(
    string Id,
    string {{multitenant_name}}Id
    /* ... */) : {{multitenant_name}}EntityInput(Id, {{multitenant_name}}Id);