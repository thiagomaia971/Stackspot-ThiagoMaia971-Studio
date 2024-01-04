using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Company;

public static class CreateCompanyRequest
{
    public record Query([FromBody] CompanyDto payload) : CreateRequest.Query<CompanyDto>(payload);

    [EndpointRequest(
        method: EndpointMethod.POST, 
        version: "v1", 
        endpoint: "Company", 
        requireAuthorization: true, 
        new string[] { "ac337365-e690-4c75-9f05-e5ea75caa1e5" })]
    public class Handler
        (
            ICompanyRepository repository
        )
        : CreateRequest.Handler<Query, Domain.Models.Company, CompanyDto, ICompanyRepository>(repository)
    {
    }
}