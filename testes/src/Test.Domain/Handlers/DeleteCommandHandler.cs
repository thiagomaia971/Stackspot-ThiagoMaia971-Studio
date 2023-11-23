using AutoMapper;
using MediatR;
using Test.Domain.Models;
using Test.Domain.Endpoints.Base;
using Test.Domain.ViewModels.Base;
using Test.Domain.Interfaces.Repositories.Base;

namespace Test.Domain.Handlers;

public class DeleteRequestHandlerCreateRequest<TEntity, TInputDto, IOutputDto, IRepository>
    : IRequestHandler<DeleteRequest<IOutputDto>, IOutputDto>
    where TEntity : Entity
    where TInputDto : InputDto
    where IOutputDto : OutputDto
    where IRepository : IRepository<TEntity>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public DeleteRequestHandlerCreateRequest(
        IMapper mapper,
        IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IOutputDto> Handle(DeleteRequest<IOutputDto> request, CancellationToken cancellationToken)
    {
        var entity = await _repository.FindById(request.Id);

        if (entity is null)
            return null;
        await _repository.Remove(entity);
        return _mapper.Map<IOutputDto>(entity);
    }
}