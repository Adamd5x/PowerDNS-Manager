﻿using hiPower.Abstracts;
using hiPower.Database;
using hiPower.Entity;
using Microsoft.EntityFrameworkCore;

namespace hiPower.Repository
{
    public class UnitOfWork(DbContextOptions<ManagerDbContext> options) : IUnitOfWork
    {
        private bool _disposed = false;
        private readonly ManagerDbContext dbContext = new(options);

        private IGenericRepository<ServerLocation>? dataCenterRepository;
        private IGenericRepository<Server>? serverRepository;

        public IGenericRepository<ServerLocation> DataCenterRepository => dataCenterRepository ??= new GenericRepository<ServerLocation> (dbContext);

        public IGenericRepository<Server> ServerRepository => serverRepository ??= new GenericRepository<Server> (dbContext);

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
