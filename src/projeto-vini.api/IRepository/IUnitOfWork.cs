namespace projeto_vini.api.IRepository
{
  public interface IUnitOfWork : IDisposable
  {
    Task<int> SaveChangesAsync();
    int SaveChanges();
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
  }
}
