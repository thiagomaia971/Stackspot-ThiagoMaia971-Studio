

builder.AddExecutable(
    name: "Run Migration {{solution_name}}.{{api_name}}", 
    command: ".\\..\\..\\ci\\run-migration.bat",
    workingDirectory: "../{{solution_name}}.Infrastructure",
    args: new string[] { "./../{{solution_name}}.{{api_name}}" });

var {{api_name | camelcase}} = builder.AddProject<Projects.{{solution_name}}_{{api_name}}>("{{solution_name}}.{{api_name}}");
