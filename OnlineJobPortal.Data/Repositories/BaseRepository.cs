using Microsoft.EntityFrameworkCore.Storage;
using OnlineJobPortal.Data.Contexts;
using OnlineJobPortal.Data.Contracts;

namespace OnlineJobPortal.Data.Repositories;

public class BaseRepository<TEntity>(OnlineJobPortalDbContext onlineJobPortalDbContext) : IBaseRepository<TEntity> where TEntity : class
{
    private readonly OnlineJobPortalDbContext _context = onlineJobPortalDbContext;

    public virtual async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public async Task<IDbContextTransaction> BeginTransactionAsync() => await _context.Database.BeginTransactionAsync();
    public async Task CommitTransactionAsync() => await _context.Database.CommitTransactionAsync();
    public Task DeleteAsync(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
        return Task.CompletedTask;
    }

    public async Task<IQueryable<TEntity>> GetAllAsync()
    {
        return await Task.FromResult(_context.Set<TEntity>().AsQueryable());
    }

    public async Task<TEntity?> GetByIdAsync<TId>(TId id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task SaveChangesAsync() => await _context.SaveChangesAsync();

    public Task UpdateAsync(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
        return Task.CompletedTask;
    }
}
