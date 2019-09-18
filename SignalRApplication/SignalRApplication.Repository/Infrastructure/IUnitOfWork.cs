using System;
using System.Collections.Generic;
using System.Text;

namespace SignalRApplication.Repository.Infrastructure
{
    public interface IUnitOfWork : IDisposable
    {
        int Commit();
    }
}
