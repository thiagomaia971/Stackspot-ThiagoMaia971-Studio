        services
            .AddScoped<Microsoft.EntityFrameworkCore.DbContext, {{solution_name}}DbContext>()
            .AddDbContext<{{solution_name}}DbContext>(
                x =>
                {
                    var connectionString = configuration.GetConnectionString("DefaultConnection");
                    x.UseMySQL(connectionString);
                }, ServiceLifetime.Scoped, ServiceLifetime.Scoped);

