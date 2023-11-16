using AutoMapper;
using Test.Domain.ViewModels.Base;
// using DynamoDbMapper.Sdk.Entities;
// using Test.Domain.Models.Identity;
// using Test.Domain.ViewModels.AtendimentoViewModels;
// using Test.Domain.ViewModels.Base;
// using Test.Domain.ViewModels.MaterialViewModels;
// using Test.Domain.ViewModels.PacienteViewModels;
// using Test.Domain.ViewModels.UserViewModels;

namespace Test.Domain.Models.AutoMappers;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() {
        /*
        CreateMapEntity<Paciente, PacienteInput, PacienteOutput>(
            (x => x.Hash , x => x.Nome),
            (x => x.Nome, x=> x.Hash));
        
        CreateMapEntity<Material, MaterialInput, MaterialOutput>(
            (x => x.Hash , x => x.Nome),
            (x => x.Nome, x=> x.Hash));
        
        CreateMapEntity<AtendimentoMaterial, AtendimentoMaterialInput, AtendimentoMaterialOutput>();
        CreateMapEntity<Atendimento, AtendimentoInput, AtendimentoOutput>();
        
        CreateMapEntity<Clinica, ClinicaInput, ClinicaOutput>(
            (x => x.Hash , x => x.Nome));
        
        CreateMapEntity<Agenda, AgendaInput, AgendaOutput>(
            (x => x.Hash , x => x.ClinicaId),
            (x => x.Id, x => x.AgendaId));*/
        
        // CreateMaps<Usuario, UserInput, UserOutput>()
        //     .AddInputToEntityMap(input => input.Email, entity => entity.Gsi1Id)
        //     .AddInputToEntityMap(input => input.Username, entity => entity.Gsi1Hash)
        //     .AddEntityToOutputMap(opt => opt.MapFrom(x => x.Gsi1Id), output => output.Email)
        //     .AddEntityToOutputMap(opt => opt.MapFrom(x => x.Gsi1Hash), output => output.Username)
        //     .Finish();
        
        
        // CreateMaps<Material, MaterialInput, MaterialOutput>()
        //     .AddInputToEntityMap(input => input.Nome, entity => entity.Gsi1Id)
        //     .AddEntityToOutputMap(opt => opt.MapFrom(x => x.Gsi1Id), output => output.Nome)
        //     .Finish();
        
        // CreateMaps<Atendimento, AtendimentoInput, AtendimentoOutput>()
        //     .AddInputToEntityMap(input => input.PacienteId, entity => entity.Hash)
        //     .AddEntityToOutputMap(opt => opt
        //             .MapFrom(x => x.Hash),
        //         output => output.PacienteId)
        //     .Finish();
    }
    
    private AutoMapperBuilder<TEntity, TInput, TOutput> CreateMaps<TEntity, TInput, TOutput>()
        where TEntity : Entity
        where TInput : InputDto
        where TOutput : OutputDto 
    {
        return AutoMapperBuilder<TEntity, TInput, TOutput>.Create(
            CreateMap<TInput, TEntity>(),
            CreateMap<TEntity, TOutput>(),
            CreateMap<Pagination<TEntity>, Pagination<TOutput>>());
    }
}