using {{solution_name}}.Api;
using {{solution_name}}.Api.Endpoints.Base;
using {{solution_name}}.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .AddEndpointDefinitions(typeof(IEndpointDefinition))
    .AddServices(builder.Configuration, builder.Environment);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpointDefinitions();
//app.MapControllers();

app.Run();