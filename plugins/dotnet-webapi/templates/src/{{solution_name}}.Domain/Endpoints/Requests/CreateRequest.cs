using AutoMapper;
using DynamoDbMapper.Sdk.Entities;
using DynamoDbMapper.Sdk.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.Endpoints.Requests;

public static class CreateRequest 
{
    public record Query<TInputDto>(TInputDto Payload) : IHttpRequest where TInputDto : InputDto;
    
    public class Handler<TQuery, TEntity, TInputDto, IOutputDto, IRepository>
        (IMapper mapper, IRepository repository)
        : HttpHandlerBase<TQuery, TEntity>, IRequestHandler<TQuery, IResult> 
        where TQuery : Query<TInputDto>
        where TEntity : Entity
        where TInputDto : InputDto 
        where IOutputDto : OutputDto 
        where IRepository : IRepository<TEntity>
    {
        public virtual async Task<IResult> Handle(Query<TInputDto> request, CancellationToken cancellationToken)
        {
            var entity = mapper.Map<TEntity>(request.Payload);
            {% if is_dynamodb == "true" %}
            if (!string.IsNullOrEmpty(entity.Gsi1Id))
            {
                var entityExist =  await repository
                    .CreateQuery()
                    .ByGsi(x => x.Gsi1Id, entity.Gsi1Id)
                    .ByInheritedType()
                    .FindAsync();
            
                if (entityExist is not null)
                    return Results.Ok(mapper.Map<IOutputDto>(entityExist));
            }
            {%endif%}
                
            var outputDto = mapper.Map<IOutputDto>(await repository.Save(entity));
            return Results.Ok(outputDto);
        }
    }
}