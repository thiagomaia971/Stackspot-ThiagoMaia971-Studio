﻿namespace {{solution_name}}.Shared.ViewModels;

public class UserInfo
{
    public bool IsAuthenticated { get; set; }
    public string UserName { get; set; }
    public Dictionary<string, string> ExposedClaims { get; set; }
}
