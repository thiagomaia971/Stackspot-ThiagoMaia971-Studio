using DynamoDbMapper.Sdk.Interfaces;
using Test.Domain.Models.Identity;

namespace Test.Domain.Interfaces.Repositories;

public interface IUserRepository : IRepository<User>
{
    Task<IEnumerable<string>> GetRoles(string userId);
}