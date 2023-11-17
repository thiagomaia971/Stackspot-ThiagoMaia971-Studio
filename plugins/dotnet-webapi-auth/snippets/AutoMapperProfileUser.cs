        CreateMaps<User, UserInput, UserOutput>()
            .AddInputToEntityMap(input => input.Email, entity => entity.Gsi1Id)
            .AddInputToEntityMap(input => input.Username, entity => entity.Gsi1Hash)
            .AddEntityToOutputMap(opt => opt.MapFrom(x => x.Gsi1Id), output => output.Email)
            .AddEntityToOutputMap(opt => opt.MapFrom(x => x.Gsi1Hash), output => output.Username)
            .Finish();