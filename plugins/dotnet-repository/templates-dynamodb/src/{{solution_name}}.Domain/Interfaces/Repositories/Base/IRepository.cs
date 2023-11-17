using {{solution_name}}.Domain.Models;

namespace {{solution_name}}.Domain.Interfaces.Repositories.Base;

public interface IRepository<T> : DynamoDbMapper.Sdk.Interfaces.IRepository<T> 
    where T : Entity 
{
}