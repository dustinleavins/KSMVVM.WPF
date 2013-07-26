
using System;

namespace KSMVVM.WPF.Testing
{
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
}
