namespace {{solution_name}}.Domain.Endpoints.Base;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
public class HttpRequest(
    HttpMethod httpMethod, 
    string version, 
    string endpoint, 
    string[]? authorizeRole = null, 
    bool? isMultiTenant = null) : Attribute
{
    public Type QueryType { get; } = requestType;
    public HttpMethod HttpMethod { get; } = httpMethod;
    public string Version { get; } = version;
    public string Endpoint { get; } = endpoint;
    public string[]? AuthorizeRole { get; } = authorizeRole;
    public bool? IsMultiTenant { get; } = isMultiTenant;
}