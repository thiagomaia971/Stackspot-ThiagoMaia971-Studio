
using System.Text.Json.Serialization;
using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;
public class UserRoleDto(string Id, DateTime createdAt, DateTime? updatedAt, string roleId, RoleDto role, string userId, UserDto user) : BaseDto(Id, createdAt, updatedAt)
{
    #region Properties
    
    [JsonIgnore]
    public override string GetKey => RoleId;
    [JsonIgnore]
    public override string GetValue => RoleId;

    public string RoleId { get; set; } = roleId;
    public RoleDto Role { get; set; } = role;
    public string UserId { get; set; } = userId;
    public UserDto User { get; set; } = user;

    #endregion
}
