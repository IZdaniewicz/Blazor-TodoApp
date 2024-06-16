using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models;

[Table("users")]
public class User
{
    [Column("id")] public int Id { get; set; }
    [Column("name")] public string Name { get; set; } = null!;
    [Column("email")] public string Email { get; set; } = null!;
    [Column("password")] public string Password { get; set; } = null!;
    public List<TodoItem> TodoItems = new();
}