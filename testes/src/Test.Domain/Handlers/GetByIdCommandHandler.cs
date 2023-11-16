using AutoMapper;
using MediatR;
using Test.Domain.Models;
using Test.Domain.Commands;
using Test.Domain.ViewModels.Base;
using Test.Domain.Interfaces.Repositories.Base;

namespace Test.Domain.Handlers;

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