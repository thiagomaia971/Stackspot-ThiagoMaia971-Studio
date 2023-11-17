using Amazon.DynamoDBv2.DataModel;
using DynamoDbMapper.Sdk.Entities;
using DynamoDbMapper.Sdk.Repositories;
using Test.Domain.Interfaces.Repositories;
using Test.Domain.Models;

namespace Test.Infrastructure.Repositories;

public class PatientRepository : Repository<Patient>, IPatientRepository
{
    public PatientRepository(
        IDynamoDBContext dynamoDbContext, 
        MultiTenantScoped multiTenant) 
        : base(dynamoDbContext, multiTenant)
    {
    }
}