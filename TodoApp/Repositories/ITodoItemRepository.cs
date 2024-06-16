using TodoApp.Models;

namespace TodoApp.Repositories;

public interface ITodoItemRepository: IRepository<TodoItem>
{
    public IEnumerable<TodoItem> GetAllUserTodos(int userId);
    public IEnumerable<TodoItem> GetAllUserTodosForSpan(int userId,DateOnly start, DateOnly end);
}