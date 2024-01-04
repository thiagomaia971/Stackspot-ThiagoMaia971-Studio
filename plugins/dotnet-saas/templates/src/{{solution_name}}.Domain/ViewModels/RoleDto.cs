using System.Text.Json.Serialization;
using CruderSimple.Core.ViewModels;

namespace {{solution_name}}.Domain.ViewModels;

public class RoleDto : BaseDto
{
    [JsonIgnore]
    public override string GetKey => Id;
    [JsonIgnore]
    public override string GetValue => Name;

    public string Name { get; set; }

    public IEnumerable<PermissionDto> Permissions { get; set; } = new List<PermissionDto>();

    public RoleDto() : base(null, DateTime.MinValue, null)
    {
    }

    public RoleDto(
        string id,
        DateTime createdAt, 
        DateTime? updatedAt,
        string companyId,
        string name,
        IEnumerable<PermissionDto> permissions) : base(id, createdAt, updatedAt)
    {
        Name = name;
        Permissions = permissions;
    }

    public List<string> GetPermissionsBadge()
    {
        var permissions = new List<string>();
        foreach(var permission in Permissions.Where(x => x.IsRead || x.IsWrite) ?? new List<PermissionDto>())
        {
            var types = new List<string>();
            if (permission.IsRead)
                types.Add("READ");
            if (permission.IsWrite)
                types.Add("WRITE");
            permissions.Add($"{@permission.Route.Name.ToUpper()}:{string.Join(",", types)}");
        }

        return permissions;
    }

}
