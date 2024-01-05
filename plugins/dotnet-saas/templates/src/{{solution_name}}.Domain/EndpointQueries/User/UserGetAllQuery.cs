using CruderSimple.Core.EndpointQueries;

namespace {{solution_name}}.Domain.EndpointQueries.User
{
    public record UserGetAllQuery(string select, string filter, string orderBy, int page, int size) 
        : GetAllEndpointQuery(select, filter, orderBy, page, size);
}
