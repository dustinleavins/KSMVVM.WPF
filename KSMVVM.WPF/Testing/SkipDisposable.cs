
using System;

namespace KSMVVM.WPF.Testing
{
    /// <summary>
    /// Class that does the work of Skippable.Skip()
    /// </summary>
    public sealed class SkipDisposable : IDisposable
    {
        public SkipDisposable(SkippableData instance)
        {
            _instance = instance;
            _instance.Skip = true;
        }

        public void Dispose()
        {
            _instance.Skip = false;
        }

        private SkippableData _instance;
    }
}
