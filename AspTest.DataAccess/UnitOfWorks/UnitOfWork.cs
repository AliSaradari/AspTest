using AspTest.Common.UnitOfWorks;
using AspTest.DataAccess.DbContexts;

namespace AspTest.DataAccess.UnitOfWorks;

public class UnitOfWork(EFDataContext dataContext) : IUnitOfWork
{
    public async Task BeginTransaction()
    {
        await dataContext.Database.BeginTransactionAsync();
    }

    public async Task CommitTransaction()
    {
        await dataContext.SaveChangesAsync();
        await dataContext.Database.CommitTransactionAsync();
    }

    public async Task RollbackTransaction()
    {
        await dataContext.Database.RollbackTransactionAsync();
    }

    public async Task Complete()
    {
        await dataContext.SaveChangesAsync();
    }
}