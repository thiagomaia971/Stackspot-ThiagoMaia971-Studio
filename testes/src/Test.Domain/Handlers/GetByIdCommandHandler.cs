using AutoMapper;
using MediatR;
using Test.Domain.Models;
using Test.Domain.Endpoints.Base;
using Test.Domain.ViewModels.Base;
using Test.Domain.Interfaces.Repositories.Base;

namespace Test.Domain.Handlers;

public class GetByIdRequestHandler<TEntity, IOutputDto, IRepository>
    : IRequestHandler<GetByIdRequest<IOutputDto>, IOutputDto>
    where TEntity : Entity
    where IOutputDto : OutputDto
    where IRepository : IRepository<TEntity>
{
    private readonly IMapper _mapper;
    private readonly IRepository _repository;

    public GetByIdRequestHandler(
        IMapper mapper,
        IRepository repository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task<IOutputDto> Handle(GetByIdRequest<IOutputDto> request, CancellationToken cancellationToken)
    {
        var single = await _repository.FindById(request.Id);
        return single is null ? null : _mapper.Map<IOutputDto>(single);
    }
}