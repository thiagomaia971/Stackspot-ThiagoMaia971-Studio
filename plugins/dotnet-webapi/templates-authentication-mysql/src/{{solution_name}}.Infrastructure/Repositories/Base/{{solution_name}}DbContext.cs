using {{solution_name}}.Domain.Models.Identity;



    public DbSet<User> User { get; set; }
    public DbSet<UserRole> UserRole { get; set; }
    public DbSet<Role> Role { get; set; }
    public DbSet<{{multitenant_name}}> {{multitenant_name}} { get; set; }
