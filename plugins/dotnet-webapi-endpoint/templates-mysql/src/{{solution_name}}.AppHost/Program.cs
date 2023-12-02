builder.AddExecutable(
    name: "Initial Migration", 
    command: ".\\..\\..\\ci\\add-migration.bat {{entity_name}}",
    workingDirectory: "../{{solution_name}}.Infrastructure");

