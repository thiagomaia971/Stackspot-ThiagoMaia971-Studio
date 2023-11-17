using AutoMapper;
using MediatR;
using Newtonsoft.Json;
using Test.Domain.Models;
using Test.Domain.Commands;
using Test.Domain.ViewModels.Base;
using Test.Domain.Interfaces.Repositories.Base;

namespace Test.Domain.Handlers;

public class PutCommandHandlerCreateCommand<TEntity, TInputDto, IOutputDto, IRepository>
    : IRequestHandler<PutCommand<TInputDto, IOutputDto>, IOutputDto>
    where TEntity : Entity
    where TInputDto : InputDto
    where IOutputDto : OutputDto
    where IRepository : IRepository<TEntity>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public PutCommandHandlerCreateCommand(
        IMapper mapper,
        IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IOutputDto> Handle(PutCommand<TInputDto, IOutputDto> request, CancellationToken cancellationToken)
    {
        var entity = await _repository.FindById(request.Id);
        if (entity is null)
            return null;

        var entityMapped = _mapper.Map(request.Payload, entity);
        return _mapper.Map<IOutputDto>(await _repository.Save(entityMapped));
        /*
        var entity = await _repository.CreateQuery().ById(request.Id).ByHash(request.Id).FindAsync();
        var oldEntity = JsonConvert.DeserializeObject<TEntity>(JsonConvert.SerializeObject(entity));

        if (entity is null)
            return null;

        //var oldHash = entity.Hash;
        var entityMapped = _mapper.Map(request.Payload, entity);
        //var newHash = entity.Hash;
        if (entity.Hash != oldEntity.Hash) await _repository.Remove(oldEntity);
        return _mapper.Map<IOutputDto>(await _repository.Save(entityMapped));
        */
    }
}