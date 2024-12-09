using hiPower.Abstracts;
using hiPower.Database;
using hiPower.Entity;
using Microsoft.EntityFrameworkCore;

namespace hiPower.Repository
{
    public class UnitOfWork(DbContextOptions<ManagerDbContext> options) : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly ManagerDbContext dbContext = new(options);

        private IGenericRepository<DataCenter>? dataCenterRepository;
        private IGenericRepository<ServiceDetails>? serverRepository;

        public IGenericRepository<DataCenter> DataCenterRepository => dataCenterRepository ??= new GenericRepository<DataCenter> (dbContext);

        public IGenericRepository<ServiceDetails> ServerRepository => serverRepository ??= new GenericRepository<ServiceDetails> (dbContext);

        public async Task SaveAsync ()
        {
            await dbContext.SaveChangesAsync ();
        }

        #region IDisposable
        public void Dispose ()
        {
            Dispose (true);
            GC.SuppressFinalize (this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed) 
            {
                if (disposing) 
                { 
                    dbContext.Dispose ();
                }
                _disposed = true;
            }

        }
        #endregion IDisposable
    }
}
