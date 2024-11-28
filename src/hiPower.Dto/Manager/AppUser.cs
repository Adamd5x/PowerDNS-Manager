﻿namespace hiPower.Dto.Manager;

public class AppUser
{
    public string Id { get; }
    public string Name { get; }
    public string Email { get; }

    public AppUser(string id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}