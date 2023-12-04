using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels.{{multitenant_name}};

public record {{multitenant_name}}Input(
    string Id,
    string Name
    /* ... */) : InputDto(Id);