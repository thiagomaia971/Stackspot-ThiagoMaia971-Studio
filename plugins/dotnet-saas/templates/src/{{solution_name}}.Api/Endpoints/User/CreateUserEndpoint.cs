using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.Core.Entities;
using CruderSimple.Core.ViewModels;
using CruderSimple.Core.Extensions;
using Force.DeepCloner;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.User;

public static class CreateRoleEndpoint
{
    public record Query([FromBody] UserDto payload) : CreateRequest.Query<UserDto>(payload);

    [EndpointRequest(
        method: EndpointMethod.POST, 
        version: "v1", 
        endpoint: "User", 
        requireAuthorization: true, 
        new string[] {  })]
    public class Handler
        (
            IUserRepository repository,
            UserManager<Domain.Models.Identity.User> userManager,
            SignInManager<Domain.Models.Identity.User> _signInManager
        )
        : CreateRequest.Handler<Query, Domain.Models.Identity.User, UserDto, IUserRepository>(repository)
    {
        public override async Task<Result> Handle(Query request, CancellationToken cancellationToken)
        {
            try
            {
                var user = (Domain.Models.Identity.User) new Domain.Models.Identity.User().FromInput(request.payload);
                var result = await userManager.CreateAsync(user, request.payload.Password);
                if (result.Succeeded)
                {
            
                    /*var code = await userManager.GenerateEmailConfirmationTokenAsync(user);
                    var callbackUrl = Url.EmailConfirmationLink(user.Id, code, Request.Scheme);
                    await _emailSender.SendEmailConfirmationAsync(model.Email, callbackUrl);*/
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    var xx = await _signInManager.CreateUserPrincipalAsync(user);
                }
                else
                    return Result.CreateError("Erro", 400, result.Errors.Select(x => $"{x.Code}: {x.Description}").ToArray());

                var resultData = (await repository.FindById(user.Id)).ToOutput<UserDto>();
                return Result.CreateSuccess(resultData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}