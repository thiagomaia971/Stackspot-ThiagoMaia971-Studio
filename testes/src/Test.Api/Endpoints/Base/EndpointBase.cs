using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Test.Domain.Models;
using Test.Domain.Commands;
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
        app.MapGet(Path, GetAll).WithTags(typeof(TEntity).Name);
        app.MapGet($"{Path}/{{id}}", GetById).WithTags(typeof(TEntity).Name);
        app.MapPost(Path, Post).WithTags(typeof(TEntity).Name);
        app.MapPut($"{Path}/{{id}}", Put).WithTags(typeof(TEntity).Name);
        app.MapDelete($"{Path}/{{id}}", Delete).WithTags(typeof(TEntity).Name);
    }

    public virtual void DefineHandlers(IServiceCollection services)
    {
        AddGetAllCommand(services);
        AddGetByIdCommand(services);
        AddCreateCommand(services);
        AddPutCommand(services);
        AddDeleteCommand(services);
    }

    protected virtual void AddGetAllCommand(IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<GetAllCommand<IOutputDto>, Pagination<IOutputDto>>,
            GetAllCommandHandler<TEntity, IOutputDto, IRepository>>();
    }

    protected virtual void AddGetByIdCommand(IServiceCollection services)
    {
        services
            .AddTransient<IRequestHandler<GetByIdCommand<IOutputDto>, IOutputDto>,
                GetByIdCommandHandler<TEntity, IOutputDto, IRepository>>();
    }

    protected virtual void AddCreateCommand(IServiceCollection services)
    {
        services
            .AddTransient<IRequestHandler<CreateCommand<TInputDto, IOutputDto>, IOutputDto>,
                CreateCommandHandler<TEntity, TInputDto, IOutputDto, IRepository>>();
    }

    protected virtual void AddPutCommand(IServiceCollection services)
    {
        services
            .AddTransient<IRequestHandler<PutCommand<TInputDto, IOutputDto>, IOutputDto>,
                PutCommandHandlerCreateCommand<TEntity, TInputDto, IOutputDto, IRepository>>();
    }

    protected virtual void AddDeleteCommand(IServiceCollection services)
    {
        services
            .AddTransient<IRequestHandler<DeleteCommand<IOutputDto>, IOutputDto>,
                DeleteCommandHandlerCreateCommand<TEntity, TInputDto, IOutputDto, IRepository>>();
    }

    protected virtual async Task<IResult> GetAll(
        [FromServices] IMapper mapper,
        [FromServices] IMediator mediator)
        => await Handle(mediator, new GetAllCommand<IOutputDto>());

    protected virtual async Task<IResult> GetById(
        [FromRoute] string id,
        [FromServices] IMediator mediator)
        => await Handle(mediator, new GetByIdCommand<IOutputDto>(id));

    protected virtual async Task<IResult> Post(
        [FromBody] TInputDto input,
        [FromServices] IMediator mediator)
        => await Handle(mediator, new CreateCommand<TInputDto, IOutputDto>(input));

    protected virtual async Task<IResult> Put(
        [FromRoute] string id,
        [FromBody] TInputDto input,
        [FromServices] IMediator mediator)
        => await Handle(mediator, new PutCommand<TInputDto, IOutputDto>(id, input));

    protected virtual async Task<IResult> Delete(
        [FromRoute] string id,
        [FromBody] TInputDto input,
        [FromServices] IMediator mediator)
        => await Handle(mediator, new DeleteCommand<IOutputDto>(id));

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
            return Results.BadRequest(e);
        }
    }
}