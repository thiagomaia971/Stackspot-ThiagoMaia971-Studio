using AutoMapper;
using MediatR;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Commands;
using {{solution_name}}.Domain.ViewModels.Base;
using {{solution_name}}.Domain.Interfaces.Repositories.Base;

namespace {{solution_name}}.Domain.Handlers;

public class GetByIdCommandHandler<TEntity, IOutputDto, IRepository>
    : IRequestHandler<GetByIdCommand<IOutputDto>, IOutputDto> 
    where TEntity : Entity
    where IOutputDto : OutputDto 
    where IRepository : IRepository<TEntity>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public GetByIdCommandHandler(
        IMapper mapper,
        IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public async Task<IOutputDto> Handle(GetByIdCommand<IOutputDto> request, CancellationToken cancellationToken)
    {
        var single = await _repository.FindById(request.Id);
        return single is null ? null : _mapper.Map<IOutputDto>(single);
    }
}