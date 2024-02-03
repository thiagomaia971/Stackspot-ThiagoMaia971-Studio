using CruderSimple.Core.EndpointQueries;

namespace {{solution_name}}.Domain.EndpointQueries.{{multitenant_name}}
{
    public record {{multitenant_name}}GetAllQuery(
        string select = "*", 
        string filter = "",
        string orderBy = "",
        int size = 10, 
        int page = 1,
        int skip = 0) : GetAllEndpointQuery(select, filter, orderBy, size, page, skip);
}
