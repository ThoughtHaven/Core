using System;

namespace ThoughtHaven
{
    public abstract class Disposable : IDisposable
    {
        public void Dispose()
        {
            this.Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        bool disposed = false;
        protected void Dispose(bool disposing)
        {
            if (disposed) { return; }

            if (disposing)
            { this.OnDispose(); }

            disposed = true;
        }

        protected abstract void OnDispose();
    }
}