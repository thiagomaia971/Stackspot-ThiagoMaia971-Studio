using Aspire.Hosting;

var builder = DistributedApplication.CreateBuilder(args);
var localstack = 
    builder.AddContainer("{{solution_name}}_mysql", "mysql", "latest")
        .WithServiceBinding(3306, 3306)
        .WithEnvironment("MYSQL_ROOT_PASSWORD", "12345")
        .WithVolumeMount("mysql_volume", "/var/lib/mysql");


builder.AddExecutable(
    name: "Run Migration {{solution_name}}.Api", 
    command: ".\\..\\..\\ci\\run-migration.bat",
    workingDirectory: "../{{solution_name}}.Infrastructure",
    args: new string[] { "./../{{solution_name}}.Api" });

var api = builder.AddProject<Projects.{{solution_name}}_Api>("{{solution_name}}.Api")
    .WithServiceBinding({{api_host_port}}, "http", "{{solution_name}}api");
var web = builder.AddProject<Projects.{{solution_name}}_Web>("{{solution_name}}.Web")
    .WithReference(api);
builder.Build().Run();
