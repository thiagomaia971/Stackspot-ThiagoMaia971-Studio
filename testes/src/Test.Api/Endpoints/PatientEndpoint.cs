using MediatR;
using Test.Api.Filters;
using Test.Api.Endpoints.Base;
using Test.Domain.Interfaces.Repositories;
using Test.Domain.Models;
using Test.Domain.ViewModels.PatientViewModels;
using Test.Domain.Interfaces.Repositories;
using Test.Domain.Interfaces.Repositories.Base;


namespace Test.Api.Endpoints;

public class PatientEndpoint : EndpointBase<Patient, PatientInput, PatientOutput, IPatientRepository>
{
    public override string Path => "/v1/Patient";
    public override string[] AuthorizeRole => Array.Empty<string>();

    public override void DefineEndpoints(WebApplication app)
    {
        app.MapGet(Path, GetAll).WithTags(nameof(Patient));
        app.MapGet($"{Path}/{{id}}", GetById).WithTags(nameof(Patient)).RequireAuthorization(AuthorizeRole).AddEndpointFilter<MultiTenantActionFilter>();
        app.MapPost(Path, Post).WithTags(nameof(Patient)).RequireAuthorization(AuthorizeRole).AddEndpointFilter<MultiTenantActionFilter>();
        app.MapPut($"{Path}/{{id}}", Put).WithTags(nameof(Patient)).RequireAuthorization(AuthorizeRole).AddEndpointFilter<MultiTenantActionFilter>();
        app.MapDelete($"{Path}/{{id}}", Delete).WithTags(nameof(Patient)).RequireAuthorization(AuthorizeRole).AddEndpointFilter<MultiTenantActionFilter>();
    }
}