using AutoMapper;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Models.AutoMappers;

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