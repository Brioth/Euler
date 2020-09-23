using System;
using System.Collections.Generic;
using System.Text;

namespace Euler.Data
{
    public interface IUnitOfWork : IDisposable
    {
        IProblemRepository Problems { get; }

        void Save();
    }
}
