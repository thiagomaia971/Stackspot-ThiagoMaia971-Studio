namespace {{solution_name}}.Api.Endpoints.Base;

public interface IEndpointDefinition
{
    void DefineEndpoints(WebApplication app);
    void DefineHandlers(IServiceCollection services);
}