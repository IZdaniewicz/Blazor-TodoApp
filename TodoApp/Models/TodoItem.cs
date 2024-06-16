using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models;

[Table("todo_items")]
public class TodoItem
{
    [Column("id")] public int Id { get; set; }
    [Column("user_id")] public int UserId { get; set; }
    [Column("column")] public string Content { get; set; } = null!;
    [Column("is_done")] public bool IsDone { get; set; } = false;
    [Column("date")] public DateOnly Date { get; set; }
    public User User { get; set; } = null!;
}