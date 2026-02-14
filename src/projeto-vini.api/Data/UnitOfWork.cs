using Microsoft.EntityFrameworkCore.Storage;
using projeto_vini.api.IRepository;

namespace projeto_vini.api.Data
{
  public class UnitOfWork : IUnitOfWork
  {
    private readonly ApiDbContext _context;
    private IDbContextTransaction _transaction;

    public UnitOfWork(ApiDbContext context)
    {
      _context = context;
    }

    public async Task<int> SaveChangesAsync()
    {
      return await _context.SaveChangesAsync();
    }

    public int SaveChanges()
    {
      return _context.SaveChanges();
    }

    public async Task BeginTransactionAsync()
    {
      _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
      try
      {
        await SaveChangesAsync();
        await _transaction?.CommitAsync();
      }
      catch
      {
        await RollbackTransactionAsync();
        throw;
      }
      finally
      {
        _transaction?.Dispose();
        _transaction = null;
      }
    }

    public async Task RollbackTransactionAsync()
    {
      await _transaction?.RollbackAsync();
      _transaction?.Dispose();
      _transaction = null;
    }

    public void Dispose()
    {
      _transaction?.Dispose();
      _context?.Dispose();
    }
  }
}
