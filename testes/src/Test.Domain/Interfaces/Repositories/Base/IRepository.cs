using Test.Domain.Models;

namespace Test.Domain.Interfaces.Repositories.Base;

public interface IRepository<T> : DynamoDbMapper.Sdk.Interfaces.IRepository<T>
    where T : Entity
{
}