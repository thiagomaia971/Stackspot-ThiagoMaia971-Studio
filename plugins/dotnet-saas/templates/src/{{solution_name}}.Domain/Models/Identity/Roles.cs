namespace {{solution_name}}.Domain.Models.Identity;

public static class Roles
{
    public const string ADMIN = "ac337365-e690-4c75-9f05-e5ea75caa1e5";
    public const string GENERIC = "0439ac1d-c8aa-4d9b-b7b7-68d5c562eac7";

    public static string[] ALL
        => new []
        {
            ADMIN,
            GENERIC
        };
}

public static class Policy
{
    public const string READ = "READ";
    public const string WRITE = "WRITE";
    public const string ALL = "READ:WRITE";
}