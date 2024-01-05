using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using {{solution_name}}.Shared.Services;
using {{solution_name}}.Shared.Extensions;
using CruderSimple.Blazor.Extensions;

namespace {{solution_name}}.Web;
public class Program
{

    public static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);
        builder.RootComponents.Add<App>("#app");
        builder.RootComponents.Add<HeadOutlet>("head::after");

        builder.Services.AddOptions();
        builder.Services.AddCruderSimpleBlazor<AuthorizeApi>();
        // TODO: auto import

        builder.Services.Add{{solution_name}}Client();

        await builder.Build().RunAsync();
    }
}