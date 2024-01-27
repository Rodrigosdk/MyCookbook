using MyCookbook.Domain.Repositories;
using MyCookbook.Infrastructure.Database;

namespace MyCookbook.Infrastructure.Repositories;

public sealed class UnitOfWork(DataContext context) : IDisposable, IUnitWorkRepository
{
    private readonly DataContext _dataContext = context;
    private bool _disposed;

    public async Task Commit()
    {
       await _dataContext.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool dispesing)
    {
        if (!_disposed && dispesing) { _dataContext.Dispose(); }
        _disposed = true;
    }
}
