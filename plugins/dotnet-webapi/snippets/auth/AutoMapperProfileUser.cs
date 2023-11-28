        CreateMaps<User, UserInput, UserOutput>()
            .AddInputToEntityMap(input => input.Email, entity => entity.PrimaryKey)
            .AddInputToEntityMap(input => input.Username, entity => entity.PrimaryForeingKey)
            .AddEntityToOutputMap(opt => opt.MapFrom(x => x.PrimaryKey), output => output.Email)
            .AddEntityToOutputMap(opt => opt.MapFrom(x => x.PrimaryForeingKey), output => output.Username)
            .Finish();