using System;

namespace TvArchiving.Domain.Infrastructure
{

    public class Disposable:IDisposable
    {
        private bool isDisposed;
        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        public void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DisposeCore();
            }
            isDisposed = true;
        }
        
        protected virtual void DisposeCore()
        {
        }
    }
}
