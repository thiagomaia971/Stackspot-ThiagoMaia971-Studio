using AutoMapper;
using MediatR;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Endpoints.Base;
using {{solution_name}}.Domain.ViewModels.Base;
using {{solution_name}}.Domain.Interfaces.Repositories.Base;

namespace {{solution_name}}.Domain.Endpoints.Requests;

public static class GetAllRequest
{
    public record Query : IHttpRequest;

    public class Handler<TQuery, TEntity, IOutputDto, IRepository>
        (IMapper mapper, IRepository repository)
        : HttpHandlerBase<TQuery, TEntity>, IRequestHandler<Query, IResult> 
        where TQuery : Query
        where TEntity : Entity
        where IOutputDto : OutputDto 
        where IRepository : IRepository<TEntity>
    {
        public virtual async Task<IResult> Handle(Query request, CancellationToken cancellationToken)
        {
            var queryAsync = await repository.GetAll();
            return Results.Ok(mapper.Map<Pagination<IOutputDto>>(queryAsync));
        }
    }
}