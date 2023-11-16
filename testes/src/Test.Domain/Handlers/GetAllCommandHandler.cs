using AutoMapper;
using MediatR;
using Test.Domain.Models;
using Test.Domain.Commands;
using Test.Domain.ViewModels.Base;
using Test.Domain.Interfaces.Repositories.Base;

namespace Test.Domain.Handlers;

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