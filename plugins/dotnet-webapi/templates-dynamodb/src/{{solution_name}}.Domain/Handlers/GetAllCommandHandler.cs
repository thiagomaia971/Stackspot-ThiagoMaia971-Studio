using AutoMapper;
using MediatR;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Commands;
using {{solution_name}}.Domain.ViewModels.Base;
using {{solution_name}}.Domain.Interfaces.Repositories.Base;

namespace {{solution_name}}.Domain.Handlers;

public class GetAllCommandHandler<TEntity, IOutputDto, IRepository>
    : IRequestHandler<GetAllCommand<IOutputDto>, Pagination<IOutputDto>> 
    where TEntity : Entity
    where IOutputDto : OutputDto 
    where IRepository : IRepository<TEntity>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public GetAllCommandHandler(
        IMapper mapper,
        IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public async Task<Pagination<IOutputDto>> Handle(GetAllCommand<IOutputDto> request, CancellationToken cancellationToken)
    {
        var queryAsync = await _repository.GetAll();
        return _mapper.Map<Pagination<IOutputDto>>(queryAsync);
    }
}