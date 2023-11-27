using CruderSimple.Core.Requests;
using CruderSimple.DynamoDb.Requests;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels.UserViewModels;

namespace {{solution_name}}.Api.Endpoints.User;

public static class CreateUserRequest
{
    public record Query([FromBody] UserInput payload) : CreateRequest.Query<UserInput>(payload);

    [EndpointRequest(
        method: EndpointMethod.POST, 
        version: "v1", 
        endpoint: "User", 
        requireAuthorization: true, 
        new string[] { "ac337365-e690-4c75-9f05-e5ea75caa1e5" })]
    public class Handler
        (
            IUserRepository repository,
            UserManager<Domain.Models.Identity.User> userManager,
            SignInManager<Domain.Models.Identity.User> _signInManager
        )
        : CreateRequest.Handler<Query, Domain.Models.Identity.User, UserInput, UserOutput, IUserRepository>(repository)
    {
        public override async Task<IResult> Handle(Query request, CancellationToken cancellationToken)
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
            {
                return Results.BadRequest(new { result.Errors });
            }
            return Results.Ok(user.ToOutput());
        }
    }
}