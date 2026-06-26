using System.Linq.Expressions;

namespace EduMentorAI.Application.Interfaces;

public interface IGenericRepositoryMarker
{
}

public interface IGenericRepository<T> : IGenericRepositoryMarker where T : class
{
    Task<IReadOnlyList<T>> GetAllAsync();

    Task<T?> GetByIdAsync(int id);

    Task<IReadOnlyList<T>> FindAsync(Expression<Func<T, bool>> predicate);

    Task<T?> FirstOrDefaultAsync(Expression<Func<T, bool>> predicate);

    Task AddAsync(T entity);

    void Update(T entity);

    void Delete(T entity);
}