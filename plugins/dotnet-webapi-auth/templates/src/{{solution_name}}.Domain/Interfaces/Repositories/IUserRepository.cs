using CruderSimple.DynamoDb.Interfaces;
using {{solution_name}}.Domain.Models.Identity;

namespace {{solution_name}}.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<IEnumerable<string>> GetRoles(string userId);
}