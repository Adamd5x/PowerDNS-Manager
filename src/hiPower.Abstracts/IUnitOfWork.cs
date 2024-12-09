using hiPower.Entity;

namespace hiPower.Abstracts;

public interface IUnitOfWork : IDisposable
{
    IGenericRepository<Entity.DataCenter> DataCenterRepository { get; }
    IGenericRepository<Entity.ServiceDetails> ServerRepository { get; }
    Task SaveAsync ();
}
