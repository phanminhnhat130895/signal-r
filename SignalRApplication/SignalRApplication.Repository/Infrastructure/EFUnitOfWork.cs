using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Repository.Infrastructure
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private readonly EFDbContext _context;

        public EFUnitOfWork(EFDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            if(_context != null)
            {
                _context.Dispose();
            }
        }
    }
}
