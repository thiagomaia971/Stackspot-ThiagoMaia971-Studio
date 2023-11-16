// using AutoMapper;
// using Test.Domain.Commands;
// using Test.Domain.Interfaces.Repositories;
// using Test.Domain.Models;
// using Test.Domain.ViewModels.AgendaViewModels;
// using Test.Domain.ViewModels.ClinicaViewModels;

// namespace Test.Domain.Handlers.AgendaCommandHandlers;

// public class CriarAgendaCommandHandler : CreateCommandHandler<Agenda, AgendaInput, AgendaOutput, IAgendaRepository>
// {
//     private readonly IClinicaRepository _clinicaRepository;

//     public CriarAgendaCommandHandler(
//         IMapper mapper, 
//         IAgendaRepository repository,
//         IClinicaRepository clinicaRepository) : base(mapper, repository)
//     {
//         _clinicaRepository = clinicaRepository;
//     }

//     public override async Task<AgendaOutput> Handle(CreateCommand<AgendaInput, AgendaOutput> request, CancellationToken cancellationToken)
//     {
//         /*
//         var user = await _repository.Find(request.Payload.GetHash());
//         if (user is not null)
//             return null;
        
//         var clinica = await _clinicaRepository.Find(request.Payload.ClinicaId);

//         var agenda = _mapper.Map<Agenda>(request.Payload);
//         agenda.Id = clinica.Id;
//         agenda.Nome = clinica.Nome;
//         agenda.Cnpj = clinica.Cnpj;
        
//         var outputDto = _mapper.Map<AgendaOutput>(await _repository.Save(agenda));
//         return outputDto;*/
//         return null;
//     }
// }