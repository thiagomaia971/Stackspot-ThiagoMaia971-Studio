using {{solution_name}}.{{api_name}};
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);
builder.AddServiceDefaults();
// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .AddCruderSimpleServices(builder.Configuration, builder.Environment)
    .AddServices(builder.Configuration, builder.Environment);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My {{api_name}} V1");
        c.RoutePrefix = "";
    });
}

// app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

//app.MapControllers();
app.UseCruderSimpleServices();
app.Run();