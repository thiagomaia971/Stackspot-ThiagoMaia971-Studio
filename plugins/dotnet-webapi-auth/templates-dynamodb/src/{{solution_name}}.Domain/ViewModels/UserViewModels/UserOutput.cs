using {{solution_name}}.Domain.Models.Identity;
using {{solution_name}}.Domain.ViewModels.Base;

namespace {{solution_name}}.Domain.ViewModels.UserViewModels;

public class UserOutput : OutputDto
{
    public string Email { get; set; }
    public string Nome { get; set; }
    public string Username { get; set; }
    public bool EmailConfirmed { get; set; }
    public string PhoneNumber { get; set; }
    public bool PhoneNumberConfirmed { get; set; }
    public bool TwoFactorEnabled { get; set; }
    
    public List<UserRole> Roles { get; set; }
}