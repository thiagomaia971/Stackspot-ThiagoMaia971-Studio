using System.Diagnostics;
using System.Reflection;
using MediatR;
using {{solution_name}}.Api.Endpoints.Base;
using {{solution_name}}.Domain.Endpoints.Base;

namespace {{solution_name}}.Api.Extensions;

public static class EndpointDefinitionsExtensions
{
    public static IServiceCollection AddRequestDefinitions(
        this IServiceCollection services,
        Type scanMarkers)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();

        var requestHandlers = GetTypesWithHelpAttribute(scanMarkers.Assembly);

        foreach (var handler in requestHandlers)
        {
            var httpRequestAttribute = ({{solution_name}}.Domain.Endpoints.Base.HttpRequest?)
                handler.GetCustomAttributes(true).FirstOrDefault(x =>
                    typeof({{solution_name}}.Domain.Endpoints.Base.HttpRequest).IsAssignableFrom(x.GetType()));
            
            var query = handler.BaseType.GetGenericArguments().First();
            var @interface = typeof(IRequestHandler<,>).MakeGenericType(query, typeof(IResult)); 
            services.AddScoped(@interface, handler);
        }

        stopWatch.Stop();
        Console.WriteLine($"AddRequestDefinitions in: {stopWatch.ElapsedMilliseconds}ms");

        return services;
    }
    
    public static WebApplication UseRequestDefinitions(
        this WebApplication app,
        Type scanMarkers)
    {
        var stopWatch = new Stopwatch();
        stopWatch.Start();
        var requestHandlers = GetTypesWithHelpAttribute(scanMarkers.Assembly);

        var instances = requestHandlers
            .Select(x => Activator.CreateInstance(x, 
                new object[x.GetConstructors().First().GetParameters().Length]))
            .Cast<IHttpRequestHandler>();

        foreach (var handler in instances)
            handler.AddEndpointDefinition(app);

        stopWatch.Stop();
        Console.WriteLine($"UseRequestDefinitions in: {stopWatch.ElapsedMilliseconds}ms");

        return app;
    }
    
    static IEnumerable<Type> GetTypesWithHelpAttribute(Assembly assembly) {
        foreach(Type type in assembly.GetTypes()) {
            if (type.GetCustomAttributes(typeof({{solution_name}}.Domain.Endpoints.Base.HttpRequest), true).Length > 0) {
                yield return (type);
            }
        }
    }
}