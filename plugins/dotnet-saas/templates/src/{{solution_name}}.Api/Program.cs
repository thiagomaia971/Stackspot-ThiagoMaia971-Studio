using CruderSimple.MySql.Configurations;
using {{solution_name}}.Api;
using CruderSimple.Api.Extensions;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
// Add services to the container.

builder.Services.AddControllers();
//builder.Services.AddControllers().AddOdataEdmModel(builder.Services);
builder.Services
    .AddCruderSimpleServices<{{multitenant_name}}Entity>(
        configuration: builder.Configuration, 
        environment: builder.Environment, 
        multiTenantRepositoryInterface: typeof(IRepository<>), 
        multiTenantRepositoryImplementation: typeof(Repository<>))
    .AddCruderRequestDefinitions()
    .AddServices(builder.Configuration, builder.Environment);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Api V1");
        c.RoutePrefix = "";
    });
}

// app.UseHttpsRedirection();


app.UseCruderSimpleServices<User>();
//app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

//app.UseEndpoints(endpoints => endpoints.MapControllers());

app.MapControllers();

app.Run();