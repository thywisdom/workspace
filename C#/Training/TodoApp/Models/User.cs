namespace ToDoApp.Models;

public class User
{
    public int Id { get; set; }
    public string? Username { get; set; }
    public string? Password { get; set; }
    public List<Role> Roles { get; set;} = new();
}

public class Role
{
    public int Id { get; set; }
    public string? RoleName { get; set;}
    public int? UserId { get; set; }
}