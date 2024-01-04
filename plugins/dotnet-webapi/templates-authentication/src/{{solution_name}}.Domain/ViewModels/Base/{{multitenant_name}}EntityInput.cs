using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;

public record {{multitenant_name}}EntityInput(
    string Id,
    string {{multitenant_name}}Id) : InputDto(Id);