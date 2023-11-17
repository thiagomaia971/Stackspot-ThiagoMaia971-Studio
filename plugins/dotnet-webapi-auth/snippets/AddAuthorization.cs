
       services.AddAuthorization(options =>
       {
           foreach (var role in Roles.ALL)
           {
               options.AddPolicy(role, builder => builder.RequireRole(role));
               //options.AddPolicy($"{role}:{Policy.READ}", builder => builder.RequireRole(role));
               //options.AddPolicy($"{role}:{Policy.WRITE}", builder => builder.RequireRole(role));
               //options.AddPolicy($"{role}:{Policy.ALL}", builder => builder.RequireRole(role));
           }
       });
