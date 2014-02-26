// Copyright (c) 2014 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Windows.Input;

namespace KSMVVM.WPF
{
    /// <summary>
    /// <see cref="ICommand"/> implementation that calls methods on a 
    /// backing <see cref="ICommand"/> instance.
    /// </summary>
    /// <remarks>
    /// Use this class if you need to swap commands for a binding at runtime.
    /// 
    /// An example use case for a <see cref="ProxyCommand"/> instance is
    /// to act as a command for a Window-level save command. Not every page
    /// may be capable of saving data, and you can swap-in an appropriate
    /// save command depending on what page you are on.
    /// </remarks>
    public sealed class ProxyCommand : ICommand
    {
        public bool CanExecute(object parameter)
        {
            if (_cmd == null)
            {
                return false;
            }
            else
            {
                return _cmd.CanExecute(parameter);
            }
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            if (_cmd != null)
            {
                _cmd.Execute(parameter);
            }
        }

        /// <summary>
        /// Backing command for this instance.
        /// </summary>
        /// <remarks>
        /// This property can be set to null. While it's null, this
        /// instance's CanExecute method returns false.
        /// </remarks>
        public ICommand BackingCommand
        {
            get
            {
                return _cmd;
            }

            set
            {
                if (_cmd != null)
                {
                    _cmd.CanExecuteChanged -= BackingCommand_CanExecuteChanged;
                }

                if (value != null)
                {
                    value.CanExecuteChanged += BackingCommand_CanExecuteChanged;
                }

                _cmd = value;
                TriggerCanExecuteChanged(new EventArgs());
            }
        }

        private void TriggerCanExecuteChanged(EventArgs e)
        {
            var handler = CanExecuteChanged;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        void BackingCommand_CanExecuteChanged(object sender, EventArgs e)
        {
            TriggerCanExecuteChanged(e);
        }

        private ICommand _cmd;
    }
}
