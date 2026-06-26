using EduMentorAI.Application.Interfaces;
using EduMentorAI.Infrastructure.Persistence.Context;
using EduMentorAI.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace EduMentorAI.Infrastructure.UnitOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly EduMentorAiDbContext _context;
    private readonly Dictionary<Type, IGenericRepositoryMarker> _repositories = new();
    private IDbContextTransaction? _transaction;

    public UnitOfWork(EduMentorAiDbContext context)
    {
        _context = context;
    }

    public IGenericRepository<T> Repository<T>() where T : class
    {
        Type entityType = typeof(T);

        if (!_repositories.ContainsKey(entityType))
        {
            _repositories[entityType] = new GenericRepository<T>(_context);
        }

        return (IGenericRepository<T>)_repositories[entityType];
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction is not null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }
}
