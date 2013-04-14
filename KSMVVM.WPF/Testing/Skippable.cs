using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSMVVM.WPF.Testing
{
    /// <summary>
    /// Class that provides functionality to skip sections of code
    /// (for example, when performing unit testing).
    /// </summary>
    /// <remarks>
    /// This class is only meant to be used temporarily, after a
    /// ViewModel is created but before implementing a better solution
    /// for UI-specific code.
    /// </remarks>
    public static class Skippable
    {
        private static Lazy<SkippableData> instance =
            new Lazy<SkippableData>(() => new SkippableData());

        /// <summary>
        /// Invokes action unless Skippable is currently set to 'skip mode'.
        /// </summary>
        /// <param name="action"></param>
        public static void Do(Action action)
        {
            instance.Value.Do(action);
        }

        /// <summary>
        /// Puts Skippable into 'skip mode'; Do(action) does not invoke
        /// the action.
        /// </summary>
        /// <remarks>
        /// Skip() is designed to be used in a using() block.
        /// </remarks>
        /// <returns>A disposable object for use in a using() block</returns>
        public static SkipDisposable Skip()
        {
            return new SkipDisposable(instance.Value);
        }

        /// <summary>
        /// Class that does the work of Skippable.Do(action).
        /// </summary>
        public class SkippableData
        {
            public bool Skip
            {
                get
                {
                    lock (skipLock)
                    {
                        return skip;
                    }
                }
                set
                {
                    lock (skipLock)
                    {
                        skip = value;
                    }
                }
            }

            public void Do(Action action)
            {
                if (!Skip)
                {
                    action.Invoke();
                }
            }

            private object skipLock = new object();
            private bool skip;
        }

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
}
