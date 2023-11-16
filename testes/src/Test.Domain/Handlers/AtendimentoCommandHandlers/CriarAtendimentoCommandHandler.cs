// using AutoMapper;
// using DynamoDbMapper.Sdk.Interfaces;
// using Test.Domain.Commands;
// using Test.Domain.Models;
// using Test.Domain.ViewModels.AtendimentoViewModels;

// namespace Test.Domain.Handlers.AtendimentoCommandHandlers;

// public class CriarAtendimentoCommandHandler : CreateCommandHandler<Atendimento, AtendimentoInput, AtendimentoOutput,
//     IRepository<Atendimento>>
// {
//     private readonly IRepository<Paciente> _pacienteRepository;

//     public CriarAtendimentoCommandHandler(
//         IMapper mapper, 
//         IRepository<Atendimento> repository,
//         IRepository<Paciente> pacienteRepository) : base(mapper, repository)
//     {
//         _pacienteRepository = pacienteRepository;
//     }

//     public override async Task<AtendimentoOutput> Handle(CreateCommand<AtendimentoInput, AtendimentoOutput> request, CancellationToken cancellationToken)
//     {
//         var atendimento = _mapper.Map<Atendimento>(request.Payload);
//         if (!string.IsNullOrEmpty(atendimento.Gsi1Id))
//         {
//             var entityExist =  await _repository
//                 .CreateQuery()
//                 .ByGsi(x => x.Gsi1Id, atendimento.Gsi1Id)
//                 .ByInheritedType()
//                 .FindAsync();

//             if (entityExist is not null)
//                 return _mapper.Map<AtendimentoOutput>(entityExist);
//         }

//         var paciente = await _pacienteRepository.FindById(request.Payload.PacienteId);
//         if (paciente is null)
//             return null;

//         var outputDto = _mapper.Map<AtendimentoOutput>(await _repository.Save(atendimento));
//         return outputDto;

//     }
// }