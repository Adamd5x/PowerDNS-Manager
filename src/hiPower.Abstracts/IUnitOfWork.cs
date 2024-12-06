using hiPower.Entity;

namespace hiPower.Abstracts;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<ServerLocation> DataCenterRepository { get; }
    IGenericRepository<Entity.ServerDetails> ServerRepository { get; }
    Task SaveAsync ();
}
