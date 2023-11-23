using Test.Api.Filters;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Domain.Models;
using Test.Domain.Endpoints.Base;
using Test.Domain.Handlers;
using Test.Domain.ViewModels.Base;
using Test.Domain.Interfaces.Repositories.Base;

namespace Test.Api.Endpoints.Base;

public abstract class EndpointBase<TEntity, TInputDto, IOutputDto, IRepository> : IEndpointDefinition
    where TEntity : Entity
    where TInputDto : InputDto
    where IOutputDto : OutputDto
    where IRepository : IRepository<TEntity>
{
    public abstract string Path { get; }
    public abstract string[] AuthorizeRole { get; }

    public virtual void DefineEndpoints(WebApplication app)
    {
        app.MapGet(Path, GetAll).WithTags(typeof(TEntity).Name).RequireAuthorization(AuthorizeRole).AddEndpointFilter<MultiTenantActionFilter>();
        app.MapGet($"{Path}/{{id}}", GetById).WithTags(typeof(TEntity).Name).RequireAuthorization(AuthorizeRole).AddEndpointFilter<MultiTenantActionFilter>();
        app.MapPost(Path, Post).WithTags(typeof(TEntity).Name).RequireAuthorization(AuthorizeRole).AddEndpointFilter<MultiTenantActionFilter>();
        app.MapPut($"{Path}/{{id}}", Put).WithTags(typeof(TEntity).Name).RequireAuthorization(AuthorizeRole).AddEndpointFilter<MultiTenantActionFilter>();
        app.MapDelete($"{Path}/{{id}}", Delete).WithTags(typeof(TEntity).Name).RequireAuthorization(AuthorizeRole).AddEndpointFilter<MultiTenantActionFilter>();
    }

    public virtual void DefineHandlers(IServiceCollection services)
    {
        AddGetAllRequest(services);
        AddGetByIdRequest(services);
        AddCreateRequest(services);
        AddPutRequest(services);
        AddDeleteRequest(services);
    }

    protected virtual void AddGetAllRequest(IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<GetAllRequest<IOutputDto>, Pagination<IOutputDto>>,
            GetAllRequestHandler<TEntity, IOutputDto, IRepository>>();
    }

    protected virtual void AddGetByIdRequest(IServiceCollection services)
    {
        services
            .AddTransient<IRequestHandler<GetByIdRequest<IOutputDto>, IOutputDto>,
                GetByIdRequestHandler<TEntity, IOutputDto, IRepository>>();
    }

    protected virtual void AddCreateRequest(IServiceCollection services)
    {
        services
            .AddTransient<IRequestHandler<CreateRequest<TInputDto, IOutputDto>, IOutputDto>,
                CreateRequestHandler<TEntity, TInputDto, IOutputDto, IRepository>>();
    }

    protected virtual void AddPutRequest(IServiceCollection services)
    {
        services
            .AddTransient<IRequestHandler<PutRequest<TInputDto, IOutputDto>, IOutputDto>,
                PutRequestHandlerCreateRequest<TEntity, TInputDto, IOutputDto, IRepository>>();
    }

    protected virtual void AddDeleteRequest(IServiceCollection services)
    {
        services
            .AddTransient<IRequestHandler<DeleteRequest<IOutputDto>, IOutputDto>,
                DeleteRequestHandlerCreateRequest<TEntity, TInputDto, IOutputDto, IRepository>>();
    }

    protected virtual async Task<IResult> GetAll(
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator)
        => await Handle(mediator, new GetAllRequest<IOutputDto>());

    protected virtual async Task<IResult> GetById(
        [FromRoute] string id,
        [FromServices] IMediator mediator)
        => await Handle(mediator, new GetByIdRequest<IOutputDto>(id));

    protected virtual async Task<IResult> Post(
        [FromBody] TInputDto input,
        [FromServices] IMediator mediator)
        => await Handle(mediator, new CreateRequest<TInputDto, IOutputDto>(input));

    protected virtual async Task<IResult> Put(
        [FromRoute] string id,
        [FromBody] TInputDto input,
        [FromServices] IMediator mediator)
        => await Handle(mediator, new PutRequest<TInputDto, IOutputDto>(id, input));

    protected virtual async Task<IResult> Delete(
        [FromRoute] string id,
        [FromBody] TInputDto input,
        [FromServices] IMediator mediator)
        => await Handle(mediator, new DeleteRequest<IOutputDto>(id));

    private async Task<IResult> Handle(IMediator mediator, IRequest<IOutputDto> request)
    {
        try
        {
            var outputDto = await mediator.Send(request);
            if (outputDto is null)
                return Results.NotFound();
            return Results.Ok(outputDto);
        }
        catch (Exception e)
        {
            return Results.BadRequest(e);
        }
    }

    private async Task<IResult> Handle(IMediator mediator, IRequest<Pagination<IOutputDto>> request)
    {
        try
        {
            var outputDto = await mediator.Send(request);
            if (outputDto is null)
                return Results.NotFound();
            return Results.Ok(outputDto);
        }
        catch (Exception e)
        {
            return Results.BadRequest(new Exception(e.Message));
        }
    }
}