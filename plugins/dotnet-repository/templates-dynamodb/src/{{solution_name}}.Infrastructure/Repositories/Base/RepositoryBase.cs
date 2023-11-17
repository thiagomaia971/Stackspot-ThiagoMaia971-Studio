using Amazon.DynamoDBv2.DataModel;
using {{solution_name}}.Domain.Interfaces.Repositories.Base;
using {{solution_name}}.Domain.Models;

namespace {{solution_name}}.Infrastructure.Repositories.Base;

public class Repository<TEntity> : DynamoDbMapper.Sdk.Repositories.Repository<TEntity>, IRepository<TEntity>
    where TEntity : Entity
{
    public Repository(
        IDynamoDBContext dynamoDbContext, 
        DynamoDbMapper.Sdk.Entities.MultiTenantScoped multiTenant) 
        : base(dynamoDbContext, multiTenant)
    {
    }
}