using Amazon.DynamoDBv2.DataModel;
using {{solution_name}}.Domain.Interfaces.Repositories.Base;
using {{solution_name}}.Domain.Models;

namespace {{solution_name}}.Infrastructure.Repositories.Base;

public class CustomDbContext : DbContext
{
    public CustomDbContext(DbContextOptions<CustomDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    {
        base.OnModelCreating(ModelBuilder);
    }
}