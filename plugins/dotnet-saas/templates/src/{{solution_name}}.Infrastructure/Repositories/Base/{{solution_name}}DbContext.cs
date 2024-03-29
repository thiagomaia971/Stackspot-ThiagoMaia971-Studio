using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CruderSimple.MySql.Extensions;

namespace {{solution_name}}.Infrastructure.Repositories.Base;

public class {{solution_name}}DbContext(DbContextOptions<{{solution_name}}DbContext> options, IConfiguration configuration) : DbContext(options)
{

    public DbSet<User> User { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<{{multitenant_name}}> {{multitenant_name}} { get; set; }
    public DbSet<Route> Route { get; set; }
    public DbSet<Permission> Permission { get; set; }
    protected override void OnModelCreating(ModelBuilder ModelBuilder)
    {
        // ModelBuilder.AutoInclude<{{solution_name}}DbContext>();
        ModelBuilder.FilterSoftDelete<{{solution_name}}DbContext>();
        // ModelBuilder.Entity<User>()
        //     .HasMany(x => x.Roles)
        //     .WithMany(x => x.Users)
        //     .UsingEntity<UserRole>(x => x.ToTable("UserRole"));
        base.OnModelCreating(ModelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseMySQL(connectionString);
    }
}
public class {{solution_name}}DbContextFactory() : IDesignTimeDbContextFactory<{{solution_name}}DbContext>
{
    public {{solution_name}}DbContext CreateDbContext(string[] args)
    {
       string environment = string.IsNullOrEmpty(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")) ? args[1] : Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");

        // Build config
        IConfiguration configuration = new ConfigurationBuilder()
            .AddBasePath()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .AddJsonFile($"appsettings.{environment}.json", optional: true)
            .AddEnvironmentVariables()
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<{{solution_name}}DbContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        optionsBuilder.UseMySQL(connectionString);

        return new {{solution_name}}DbContext(optionsBuilder.Options, configuration);
    }
}

internal static class IConfigurationRootExtensions
{
    public static IConfigurationBuilder AddBasePath(this IConfigurationBuilder builder)
    {
        var currentDirectory = Directory.GetCurrentDirectory();
        var startupProjectPath = Path.Combine(currentDirectory, "../EfDesignDemo.Web");
        var basePathConfiguration = Directory.Exists(startupProjectPath) ? startupProjectPath : currentDirectory;

        return builder.SetBasePath(basePathConfiguration);
    }
}