using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Repositories;

public class TodoItemRepository : ITodoItemRepository
{
    private readonly DataContext _db;

    public TodoItemRepository(DataContext db)
    {
        _db = db;
    }

    public TodoItem FindOrThrow(int id)
    {
        return _db.TodoItems.Find(id) ?? throw new KeyNotFoundException("Resource with given id doesnt exist!");
    }

    public void Add(TodoItem entity)
    {
        _db.TodoItems.Add(entity);
        _db.SaveChanges();
    }

    public void Modify(TodoItem entity)
    {
        _db.TodoItems.Entry(entity).State = EntityState.Modified;
        _db.SaveChanges();
    }

    public void Delete(TodoItem entity)
    {
        _db.TodoItems.Remove(entity);
        _db.SaveChanges();
    }

    public IEnumerable<TodoItem> GetAllUserTodos(int userId)
    {
        var todos = from todo in _db.TodoItems
            where todo.UserId == userId
            select todo;
        return todos.ToList();
    }

    public IEnumerable<TodoItem> GetAllUserTodosForSpan(int userId, DateOnly start, DateOnly end)
    {
        if (start > end)
            throw new ArgumentException("Start cant be later than end");
        
        var todos = from todo in _db.TodoItems
            where (todo.UserId == userId && start <= todo.Date && end >= todo.Date)
            select todo;
        return todos.ToList();
    }
}