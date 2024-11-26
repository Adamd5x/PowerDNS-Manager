using hiPower.Entity;

namespace hiPower.Abstracts;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<ServerLocation> LocationRepository { get; }
    IGenericRepository<Entity.Server> ServerRepository { get; }
    Task SaveAsync ();
}
