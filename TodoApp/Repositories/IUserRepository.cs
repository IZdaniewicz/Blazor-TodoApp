using TodoApp.Models;

namespace TodoApp.Repositories;

public interface IUserRepository: IRepository<User>
{
    public User? FindByCredentials(string email, string password);

    public User? FindByEmail(string email);
}