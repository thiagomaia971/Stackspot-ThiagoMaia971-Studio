using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace {{solution_name}}.Domain.ViewModels;

public class UserDto : {{multitenant_name}}EntityDto
{
    #region Properties

    [JsonIgnore]
    public override string GetKey => Id;
    [JsonIgnore]
    public override string GetValue => Name;

    [Required] [EmailAddress]
    public string Email { get; set; }
    public string Name { get; set; }

    [Required] [DataType(DataType.Password)]
    public string Password { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    public List<RoleDto> Roles { get; set; }
    public IEnumerable<PermissionDto> Permissions { get; set; }
    public IEnumerable<string> PermissionsString { get; set; }
    
    #endregion

    public UserDto() : base()
    {
    }

    public UserDto (
        string id, 
        DateTime createdAt, 
        DateTime? updatedAt,
        string {{multitenant_name}}Id,
        {{multitenant_name}}Dto {{multitenant_name}},
        string email,
        string name,
        bool emailConfirmed,
        string phoneNumber,
        bool phoneNumberConfirmed,
        bool twoFactorEnabled,
        IEnumerable<RoleDto> roles,
        // IEnumerable<PermissionOutput> permissions,
        IEnumerable<string> permissionsString) : base(id, createdAt, updatedAt, {{multitenant_name}}Id, {{multitenant_name}})
    {   
        Email = email;
        Name = name;
        EmailConfirmed = emailConfirmed;
        PhoneNumber = phoneNumber;
        PhoneNumberConfirmed = phoneNumberConfirmed;
        TwoFactorEnabled = twoFactorEnabled;
        Roles = roles.ToList();
        //Permissions = permissions;
        PermissionsString = permissionsString;
    }
}