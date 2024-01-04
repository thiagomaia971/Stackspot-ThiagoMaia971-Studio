using CruderSimple.Core.ViewModels.Login;
using {{solution_name}}.Domain.ViewModels;
using {{solution_name}}.Domain.ViewModels;
using {{solution_name}}.Shared.Services;

namespace {{solution_name}}.Shared.Interfaces.Services;

public interface IAuthorizeApi
{
    Task<LoginResult> Login(LoginViewModel login);
    Task Register(UserDto UserDto);
}
