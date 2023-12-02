using Microsoft.EntityFrameworkCore;

namespace {{solution_name}}.Infrastructure.Repositories.Base;

public class {{solution_name}}DbContext : DbContext
{
    public {{solution_name}}DbContext(DbContextOptions<{{solution_name}}DbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    {
        base.OnModelCreating(ModelBuilder);
    }
}