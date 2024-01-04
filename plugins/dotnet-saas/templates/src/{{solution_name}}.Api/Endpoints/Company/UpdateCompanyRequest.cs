using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Company;

public static class UpdateCompanyRequest
{
    public record Query([FromRoute] string id, [FromBody] CompanyDto payload ) : UpdateRequest.Query<CompanyDto>(id, payload);
    
    [EndpointRequest(
        method: EndpointMethod.PUT, 
        version: "v1", 
        endpoint: "Company/{id}", 
        requireAuthorization: true, 
        new string[] { "ac337365-e690-4c75-9f05-e5ea75caa1e5" })]
    public class Handler
        (ICompanyRepository repository)
        : UpdateRequest.Handler<Query, Domain.Models.Company, CompanyDto, ICompanyRepository>(repository)
    {
    }
}