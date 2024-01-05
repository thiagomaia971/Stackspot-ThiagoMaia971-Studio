using {{solution_name}}.Domain.ViewModels;
using {{solution_name}}.Domain.ViewModels.{{multitenant_name}};

namespace {{solution_name}}.Domain.ViewModels;

public record UserOutput(
    string Id, 
    string CreatedAt, 
    string UpdatedAt,
    string {{multitenant_name}}Id,
    {{multitenant_name}}Output {{multitenant_name}},
    string Email,
    string Name,
    bool EmailConfirmed,
    string PhoneNumber,
    bool PhoneNumberConfirmed,
    bool TwoFactorEnabled,
    ICollection<UserRoleOutput> Roles) : {{multitenant_name}}EntityOutput(Id, CreatedAt, UpdatedAt, {{multitenant_name}}Id, {{multitenant_name}});