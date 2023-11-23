using AutoMapper;
using MediatR;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Endpoints.Base;
using {{solution_name}}.Domain.ViewModels.Base;
using {{solution_name}}.Domain.Interfaces.Repositories.Base;

namespace {{solution_name}}.Domain.Endpoints.Requests;

public static class PutRequest
{
    public record Query<TInputDto>([FromRoute] string id, [FromBody] TInputDto payload) : IHttpRequest;

    public class Handler<TQuery, TEntity, TInputDto, IOutputDto, IRepository>
        (IMapper mapper, IRepository repository)
        : HttpHandlerBase<TQuery, TEntity>, IRequestHandler<Query<TInputDto>, IResult> 
        where TQuery : Query<TInputDto>
        where TEntity : Entity
        where TInputDto : InputDto 
        where IOutputDto : OutputDto 
        where IRepository : IRepository<TEntity>
    {        
        public virtual async Task<IResult> Handle(Query<TInputDto> request, CancellationToken cancellationToken)
        {
            {% if is_dynamodb == "true" %}
            var entity = await repository.CreateQuery().ById(request.id).ByHash(request.Id).FindAsync();
            var oldEntity = JsonConvert.DeserializeObject<TEntity>(JsonConvert.SerializeObject(entity));

            if (entity is null)
                return NotFound();

            //var oldHash = entity.Hash;
            var entityMapped = mapper.Map(request.Payload, entity);
            //var newHash = entity.Hash;
            if (entity.Hash != oldEntity.Hash) await _repository.Remove(oldEntity);
            return Results.Ok(mapper.Map<IOutputDto>(await _repository.Save(entityMapped)));
            {%else%}
            var entity = await repository.FindById(request.Id);
            if (entity is null)
                return NotFound();

            var entityMapped = mapper.Map(request.Payload, entity);
            return Results.Ok(mapper.Map<IOutputDto>(await repository.Save(entityMapped)));
            {%endif%}
        }
    }
}