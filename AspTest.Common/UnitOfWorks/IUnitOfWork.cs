namespace AspTest.Common.UnitOfWorks;

public interface IUnitOfWork
{
    Task BeginTransaction();

    Task CommitTransaction();

    Task RollbackTransaction();
    
    Task Complete();
}