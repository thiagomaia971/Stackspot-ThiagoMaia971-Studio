using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels.{{entity_name}}ViewModels;

public record {{entity_name}}Input(
    string Id
    /* ... */) : InputDto(Id);