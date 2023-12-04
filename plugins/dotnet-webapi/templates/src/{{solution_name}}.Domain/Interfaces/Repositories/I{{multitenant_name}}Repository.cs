using CruderSimple.{{database_name}}.Interfaces;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Domain.Models;

namespace {{solution_name}}.Domain.Interfaces.Repositories;

public interface I{{multitenant_name}}Repository : IRepository<{{multitenant_name}}>
{
}