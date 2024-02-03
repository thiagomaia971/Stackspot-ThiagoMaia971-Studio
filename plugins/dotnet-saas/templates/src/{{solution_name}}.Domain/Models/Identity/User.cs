using Newtonsoft.Json;
using CruderSimple.Core.Entities;
using CruderSimple.Core.Extensions;
using CruderSimple.MySql.Entities;
using CruderSimple.MySql.Attributes;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.Interfaces;
using CruderSimple.Core.ViewModels;
using Mapster;
using {{solution_name}}.Domain.ViewModels;

namespace {{solution_name}}.Domain.Models.Identity;

public class User : {{multitenant_name}}Entity, IUser
{
    [JsonProperty("Name")]
    public string Name { get; set; }

    [JsonProperty("Email")]
    public string Email { get; set; }

    [JsonProperty("EmailConfirmed")]
    public bool EmailConfirmed { get; set; }

    [JsonProperty("PasswordHash")]
    public string PasswordHash { get; set; }

    [JsonProperty("PhoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonProperty("PhoneNumberConfirmed")]
    public bool PhoneNumberConfirmed { get; set; }

    [JsonProperty("TwoFactorEnabled")]
    public bool TwoFactorEnabled { get; set; }

    [Include]
    public IEnumerable<UserRole> Roles { get; set; } = new List<UserRole>();

    // [Include]
    // [AutoDetach]
    // public IEnumerable<Role> Roles { get; set; } = new List<Role>();

    public override IEntity FromInput(BaseDto input) 
        => this.ParseWithContext<User, UserDto>(input, TypeAdapterConfig<UserDto, User>.NewConfig()
                .Map(
                    dest => dest.Roles,
                    src => src.Roles.Select(x => new UserRole
                    {
                        RoleId = x.Id,
                        UserId = src.Id
                    }).ToList())
                .IgnoreNullValues(true)
                .Config);

    public override BaseDto ConvertToOutput()
    {
        var userConfig = TypeAdapterConfig<User, UserDto>
            .NewConfig()
            .ShallowCopyForSameType(true)
            .Map(
                dest => dest.Roles,
                src => src
                    .Roles
                    .Where(x => x.Role != null)
                    .Select(x => x.Role)
                    .OrderBy(x => x.CreatedAt))
            .Map(
                dest => dest.PermissionsString,
                src => src.GetPermissions())
            .Ignore(dest => dest.Permissions)
            .Config;
        
        return this.Adapt<UserDto>(userConfig);
    }

    public override string GetPrimaryKey() => Email;
    public List<string> GetPermissions()
    {
        var permissions = Roles
            .Where(x => x.Role?.Permissions?.Any() ?? false)
            .SelectMany(x => x.Role.Permissions);
        var permissionsRead = permissions.Where(x => x.IsRead);
        var permissionsWrite = permissions.Where(x => x.IsWrite);
        
        return permissionsRead.Select(x => $"{x.Route.Url.ToUpper()}:READ")
                .Concat(permissionsRead.SelectMany(x => x.Route.DependsOn?.Split(",") ?? new string[0]).Select(x => $"{x.ToUpper()}:READ"))
                .Concat(permissionsWrite.Select(x => $"{x.Route.Url.ToUpper()}:WRITE"))
                .Concat(permissionsWrite.SelectMany(x => x.Route.DependsOn?.Split(",") ?? new string[0]).Select(x => $"{x.ToUpper()}:READ"))
                .Order().ToList();
    }
}