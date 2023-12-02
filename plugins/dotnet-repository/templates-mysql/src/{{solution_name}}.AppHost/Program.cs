var localstack = 
    builder.AddContainer("{{solution_name}}_mysql", "mysql", "latest")
        .WithServiceBinding(3306, 3306)
        .WithEnvironment("MYSQL_ROOT_PASSWORD", "12345")
        .WithVolumeMount("mysql_volume", "/var/lib/mysql");
builder.AddExecutable(
    name: "Initial Migration", 
    command: ".\\..\\..\\ci\\add-migration.bat Initial",
    workingDirectory: "../{{solution_name}}.Infrastructure").ApplicationBuilder
.AddExecutable(
    name: "Update Database", 
    command: ".\\..\\..\\ci\\update-database.bat",
    workingDirectory: "../{{solution_name}}.Infrastructure");

