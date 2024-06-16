namespace TodoApp.Repositories;

public interface IRepository<T> where T : class
{
    public T FindOrThrow(int id);
    public void Add(T entity);
    public void Modify(T entity);
    public void Delete(T entity);
}