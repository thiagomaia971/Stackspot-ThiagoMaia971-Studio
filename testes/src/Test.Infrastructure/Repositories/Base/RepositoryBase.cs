using Amazon.DynamoDBv2.DataModel;
using Test.Domain.Interfaces.Repositories.Base;
using Test.Domain.Models;

namespace Test.Infrastructure.Repositories.Base;

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