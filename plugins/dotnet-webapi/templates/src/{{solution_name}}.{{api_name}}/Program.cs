using CruderSimple.Api.Extensions;
using CruderSimple.MySql.Configurations;
using {{solution_name}}.{{api_name}};
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Infrastructure.Repositories.Base;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .AddCruderSimpleServices<{{multitenant_name}}Entity>(
        configuration: builder.Configuration, 
        environment: builder.Environment, 
        multiTenantRepositoryInterface: typeof(IMultiTenantRepository<>), 
        multiTenantRepositoryImplementation: typeof(MultiTenantRepository<>))
    .AddCruderRequestDefinitions()
    .AddServices(builder.Configuration, builder.Environment);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My {{{{api_name}}_name}} V1");
        c.RoutePrefix = "";
    });
}

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllers();
app.UseCruderSimpleServices();
app.Run();