using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.User;

public static class UpdateRoleRequest
{
    public record Query([FromRoute] string id, [FromBody] UserDto payload ) : UpdateRequest.Query<UserDto>(id, payload);
    
    [EndpointRequest(
        method: EndpointMethod.PUT, 
        version: "v1", 
        endpoint: "User/{id}", 
        requireAuthorization: true, 
        new string[] {  })]
    public class Handler
        (IUserRepository repository,
            UserManager<Domain.Models.Identity.User> userManager)
        : UpdateRequest.Handler<Query, Domain.Models.Identity.User, UserDto, IUserRepository>(repository)
    {
        public override async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            try
            {
                var entity = await repository.FindById(request.id);

                if (entity is null)
                    return Result.CreateError("Recurso não encontrado", 404, "Recurso não encontrado");

                var entityToSave = (Domain.Models.Identity.User) entity.FromInput(request.payload);
                entityToSave.PasswordHash = null;
                var result = await userManager.AddPasswordAsync(entityToSave, request.payload.Password);
                if (result.Succeeded)
                {
                    await repository.Update(entityToSave)
                        .Save();

                    return Result.CreateSuccess(entityToSave.ToOutput<UserDto>());
                }
                else
                    return Result.CreateError("Erro", 400, result.Errors.Select(x => $"{x.Code}: {x.Description}").ToArray());
            }
            catch (Exception exception)
            {
                return Result.CreateError(exception.StackTrace, 400, exception.Message);
            }
        }
    }
}