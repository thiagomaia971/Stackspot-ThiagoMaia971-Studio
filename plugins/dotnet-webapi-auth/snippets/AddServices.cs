        services
            .AddScoped<IUserStore<User>, UserStore>()
            .AddScoped<IRoleStore<Role>, RoleStore>()
            .AddIdentity<User, Role>()
            .AddDefaultTokenProviders();
