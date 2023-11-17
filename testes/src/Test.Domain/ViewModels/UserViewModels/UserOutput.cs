using Test.Domain.Models.Identity;
using Test.Domain.ViewModels.Base;

namespace Test.Domain.ViewModels.UserViewModels;

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