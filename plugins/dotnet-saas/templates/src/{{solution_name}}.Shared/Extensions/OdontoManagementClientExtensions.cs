using System.Net.Http.Headers;
using CruderSimple.Blazor.Extensions;
using CruderSimple.Blazor.Services;
using Microsoft.Extensions.DependencyInjection;
using {{solution_name}}.Shared.Services;

namespace {{solution_name}}.Shared.Extensions
{
    public static class {{solution_name}}ClientExtensions
    {
        public static IServiceCollection Add{{solution_name}}Client(this IServiceCollection services) 
        {
            Action<HttpClient> configureClient = client =>
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.BaseAddress = new("http://localhost:{{api_host_port}}/");
            };
            services.AddHttpClient("{{solution_name}}.Api", configureClient);
            services.AddHttpClient<RequestService>(configureClient);
            return services;
        }
        public static HttpClient Create{{solution_name}}Client(this IHttpClientFactory httpClientFactory) 
        { 
            var httpClient = httpClientFactory.CreateHttpClient("{{solution_name}}.Api");
            return httpClient;
        }
    }
}
