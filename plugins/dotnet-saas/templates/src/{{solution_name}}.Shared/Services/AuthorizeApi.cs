using System.Net.Http.Json;
using CruderSimple.Blazor.Interfaces.Services;
using CruderSimple.Blazor.Services;
using CruderSimple.Core.ViewModels;
using CruderSimple.Core.ViewModels.Login;
using {{solution_name}}.Domain.ViewModels;
using {{solution_name}}.Shared.Extensions;

namespace {{solution_name}}.Shared.Services;

public class AuthorizeApi : IAuthorizeApi
{ 
    public IHttpClientFactory  HttpClientFactory { get; }

    public AuthorizeApi(IHttpClientFactory httpClientFactory)
    {
        HttpClientFactory = httpClientFactory;
    }

    public async Task<LoginResult> Login(LoginViewModel login)
    {
        var httpClient = HttpClientFactory.Create{{solution_name}}Client();
        var result = await httpClient.PostAsJsonAsync("v1/login", login);
        if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) 
            throw new Exception(await result.Content.ReadAsStringAsync());
        result.EnsureSuccessStatusCode();
        var loginResult = await result.Content.ReadFromJsonAsync<Result<LoginResult>>();
        return loginResult.Data;
    }

    //public Task Register(UserDto UserDto)
    //{
    //    throw new NotImplementedException();
    //}
}
