using Microsoft.EntityFrameworkCore;
using TodoApp.Models;

namespace TodoApp.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _db;

    public UserRepository(DataContext db)
    {
        _db = db;
    }

    public User FindOrThrow(int id)
    {
        return _db.Users.Find(id) ?? throw new KeyNotFoundException("Resource with given id doesnt exist!");
    }

    public void Add(User entity)
    {
        _db.Users.Add(entity);
        _db.SaveChanges();
    }

    public void Modify(User entity)
    {
        _db.Users.Entry(entity).State = EntityState.Modified;
        _db.SaveChanges();
    }

    public void Delete(User entity)
    {
        _db.Users.Remove(entity);
        _db.SaveChanges();
    }

    public User? FindByCredentials(string email, string password)
    {
        return _db.Users.SingleOrDefault(u => (u.Email == email && u.Password == password));
    }

    public User? FindByEmail(string email)
    {
        return _db.Users.SingleOrDefault(u => u.Email == email);
    }
}