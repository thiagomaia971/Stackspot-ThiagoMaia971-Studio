using AutoMapper;
using MediatR;
using Test.Domain.Models;
using Test.Domain.Endpoints.Base;
using Test.Domain.ViewModels.Base;
using Test.Domain.Interfaces.Repositories.Base;

namespace Test.Domain.Handlers;

public class GetAllRequestHandler<TEntity, IOutputDto, IRepository>
    : IRequestHandler<GetAllRequest<IOutputDto>, Pagination<IOutputDto>>
    where TEntity : Entity
    where IOutputDto : OutputDto
    where IRepository : IRepository<TEntity>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public GetAllRequestHandler(
        IMapper mapper,
        IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<Pagination<IOutputDto>> Handle(GetAllRequest<IOutputDto> request, CancellationToken cancellationToken)
    {
        var queryAsync = await _repository.GetAll();
        return _mapper.Map<Pagination<IOutputDto>>(queryAsync);
    }
}