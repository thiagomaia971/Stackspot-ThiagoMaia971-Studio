using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using CruderSimple.Core.Entities;
using CruderSimple.DynamoDb.Repositories;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.Models;

namespace {{solution_name}}.Infrastructure.Repositories;

public class {{entity_name}}Repository : Repository<{{entity_name}}>, I{{entity_name}}Repository
{
    public {{entity_name}}Repository(
        IDynamoDBContext dynamoDbContext,
        IAmazonDynamoDB amazonDynamoDb, 
        MultiTenantScoped multiTenant) 
        : base(dynamoDbContext, amazonDynamoDb, multiTenant)
    {
    }
}