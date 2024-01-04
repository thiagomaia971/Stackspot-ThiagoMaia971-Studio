using CruderSimple.Api.Requests;
using CruderSimple.Api.Requests.Base;
using CruderSimple.Core.EndpointQueries;
using Microsoft.AspNetCore.Mvc;
using {{solution_name}}.Domain.EndpointQueries.Company;
using {{solution_name}}.Domain.Interfaces.Repositories;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Api.Endpoints.Company;

public static class GetAllCompanyRequest
{
    public record Query(
        [FromQuery] string select = "*", 
        [FromQuery] string filter = "", 
        [FromQuery] string orderBy = "", 
        [FromQuery] int size = 10, 
        [FromQuery] int page = 1) : CompanyGetAllQuery(select, filter, orderBy, size, page);

    [EndpointRequest(
        method: EndpointMethod.GET, 
        version: "v1", 
        endpoint: "Company", 
        requireAuthorization: true,
    new string[] { /* YOUR ROLES HERE */ })]
    public class Handler
        (ICompanyRepository repository)
        : GetAllRequest.Handler<Query, Domain.Models.Company, CompanyDto, ICompanyRepository>(repository)
    {
    }
}