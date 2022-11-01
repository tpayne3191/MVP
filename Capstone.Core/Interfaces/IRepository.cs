using System;

public class IRepository
{
    public interface IRepository<T>
    {
        Result<T> Create(T model);
        Result<List<T>> ReadAll();
        Result<T> ReadById(int id);
        Result Update(T model);
        Result Delete(int id);
    }
}
