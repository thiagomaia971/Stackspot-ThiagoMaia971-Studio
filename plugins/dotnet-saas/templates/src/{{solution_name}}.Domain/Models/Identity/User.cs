using Newtonsoft.Json;
using CruderSimple.Core.Extensions;
using CruderSimple.MySql.Entities;
using CruderSimple.MySql.Attributes;
using CruderSimple.Core.Extensions;
using CruderSimple.Core.Interfaces;
using CruderSimple.Core.ViewModels;
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

    public override Entity FromInput(BaseDto input)
    {
        base.FromInput(input);
        var UserDto = (UserDto)input;
        Email = UserDto.Email;
        Name = UserDto.Name;
        PhoneNumber = UserDto.PhoneNumber;
        Roles = Roles?.FromInput(UserDto.Roles?.Select(c => new UserRoleDto(null, DateTime.Now, null, c.Id, null, Id, null)).ToList());
        // Roles = Roles?.FromInput(UserDto.Roles);
        
        return this;
    }

    public override BaseDto ConvertToOutput(IDictionary<string, bool> cached = null)
    {
        if (cached is null)
            cached = new Dictionary<string, bool>();
        if (cached.ContainsKey(Id))
            return null;
        cached.Add(Id, true);

        return new UserDto(
            Id,
            CreatedAt,
            UpdatedAt,
            {{multitenant_name}}Id,
            {{multitenant_name}}?.ToOutput<{{multitenant_name}}Dto>(cached),
            Email,
            Name,
            EmailConfirmed,
            PhoneNumber,
            PhoneNumberConfirmed,
            TwoFactorEnabled,
            Roles?.Select(x => x.Role)?.ToOutput<Role, RoleDto>(cached)?.OrderBy(x => x?.CreatedAt),
            // Roles
            //     .Select(x => x.Role)
            //     .SelectMany(x => x.Permissions).ToList()
            //     .ToOutput<Permission, PermissionOutput>(),
            GetPermissions()
        );
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