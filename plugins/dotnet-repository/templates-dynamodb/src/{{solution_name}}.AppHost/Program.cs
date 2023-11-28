var localstack = 
    builder.AddContainer("{{solution_name}}_localstack", "localstack/localstack", "latest")
        .WithServiceBinding(4566, 4566);

var terraformInit = builder.AddExecutable("init terraform", ".\\..\\..\\ci\\terraform\\run-it.bat",
    "../../ci/terraform");
