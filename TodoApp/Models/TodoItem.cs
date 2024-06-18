using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TodoApp.Models;

[Table("todo_items")]
public class TodoItem
{
    [Column("id")]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Column("user_id")] [Required] public int UserId { get; set; }
    [Column("content")] [Required] public string Content { get; set; } = null!;
    [Column("is_done")] public bool IsDone { get; set; } = false;
    [Column("date")] public DateOnly Date { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    public User User { get; set; } = null!;
}