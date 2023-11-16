using AutoMapper;
using MediatR;
using Test.Domain.Models;
using Test.Domain.Commands;
using Test.Domain.ViewModels.Base;
using Test.Domain.Interfaces.Repositories.Base;

namespace Test.Domain.Handlers;

public class CreateCommandHandler<TEntity, TInputDto, IOutputDto, IRepository>
    : IRequestHandler<CreateCommand<TInputDto, IOutputDto>, IOutputDto> 
    where TEntity : Entity
    where TInputDto : InputDto 
    where IOutputDto : OutputDto 
    where IRepository : IRepository<TEntity>
{
    protected readonly IMapper _mapper;
    protected readonly IRepository _repository;

    public CreateCommandHandler(
        IMapper mapper,
        IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public virtual async Task<IOutputDto> Handle(CreateCommand<TInputDto, IOutputDto> request, CancellationToken cancellationToken)
    {
        var entity = _mapper.Map<TEntity>(request.Payload);
        // if (!string.IsNullOrEmpty(entity.Gsi1Id))
        // {
        //     var entityExist =  await _repository
        //         .CreateQuery()
        //         .ByGsi(x => x.Gsi1Id, entity.Gsi1Id)
        //         .ByInheritedType()
        //         .FindAsync();
        
        //     if (entityExist is not null)
        //         return _mapper.Map<IOutputDto>(entityExist);
        // }
            
        var outputDto = _mapper.Map<IOutputDto>(await _repository.Save(entity));
        return outputDto;
    }
}