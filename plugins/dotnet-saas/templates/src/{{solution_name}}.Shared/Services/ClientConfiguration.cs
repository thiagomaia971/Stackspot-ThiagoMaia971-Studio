using CruderSimple.Blazor.Interfaces.Services;
using CruderSimple.Blazor.Services;
using {{solution_name}}.Domain.Models;
using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Shared.Services;

public class ClientConfiguration
{
    public IdentityAuthenticationStateProvider authentication { get; set; }
    public ICrudService<User, UserDto> UserCrudService { get; set; }
    public ICrudService<Route, RouteDto> RouteCrudService { get; set; }
    public ICrudService<{{multitenant_name}}, {{multitenant_name}}Dto> {{multitenant_name}}CrudService { get; set; }

    public {{multitenant_name}}Dto {{multitenant_name}}Selected { get; set; }
    public UserDto User { get; set; }

    public IEnumerable<RouteDto> Routes => User.Roles
        .Where(c => c.{{multitenant_name}}Id == {{multitenant_name}}Selected.Id)
        .SelectMany(c => c.Permissions)
        .Select(c => c.Route);

    // public IEnumerable<{{multitenant_name}}Dto> {{multitenant_name}}s => User.{{multitenant_name}}s;

    public ClientConfiguration(
        IdentityAuthenticationStateProvider authentication, 
        ICrudService<User, UserDto> userCrudService, 
        ICrudService<Route, RouteDto> routeCrudService, 
        ICrudService<{{multitenant_name}}, {{multitenant_name}}Dto> {{multitenant_name}}CrudService)
    {
        this.authentication = authentication;
        UserCrudService = userCrudService;
        RouteCrudService = routeCrudService;
        {{multitenant_name}}CrudService = {{multitenant_name}}CrudService;
    }

    public async Task LoadData()
    {
        var loginResult = await authentication.GetUserInfo();
        if (loginResult is null)
        {
            Console.WriteLine("Login n encontrado");
            return;
        }
        Console.WriteLine("Login encontrado");
        User = (await UserCrudService.GetById(loginResult.UserId)).Data;
        {{multitenant_name}}Selected = User.{{multitenant_name}};
        // Routes = (await RouteCrudService.GetAll(
        //     new GetAllEndpointQuery(
        //         select: "*",
        //         filter: null,
        //         orderBy: null,
        //         size: 0,
        //         page: 0))).Data;
        // {{multitenant_name}}s = (await {{multitenant_name}}CrudService.GetAll(
        //     new GetAllEndpointQuery(
        //         select: "*",
        //         filter: $"UserId Equals {loginResult.UserId}",
        //         orderBy: null,
        //         size: 0,
        //         page: 0))).Data;

        // Routes = User.Roles
        //     .SelectMany(c => c.Permissions)
        //     .Select(c => c.Route);
        
        // Routes = User.Permissions.Select(c => c.Route)
        //     .Where(x => x.Visible)
        //     .GroupBy(x => x.Parent)
        //     .Select(x => new SideMenu.PageSide(x.Key, false, x.OrderBy(x => x.Position).Select(c => new LoginRouteResult
        //     {
        //         Icon = c.Icon,
        //         Name = c.Name,
        //         Parent = c.Parent,
        //         Position = c.Position,
        //         Url = c.Url,
        //         Visible = c.Visible
        //     }).ToList()))
        //     .ToList() ?? new List<SideMenu.PageSide>();
    }
}