namespace DAL.Repositories;

public interface IRepository<T>
{
    T GetById(Guid id);
    IEnumerable<T> GetAll();
    void Add(T entity);
    T Update(T entity);
    T Delete(Guid id);
}