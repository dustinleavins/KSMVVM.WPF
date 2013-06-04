using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace KSMVVM.WPF
{
    /// <summary>
    /// 'Basic' implementation of ICommand.
    /// </summary>
    /// <remarks>
    /// This class implements ICommand.CanExecuteChanged by just forwarding
    /// add/remove requests to CommandManager.RequerySuggested.
    /// CanExecuteDelegate will be constantly invoked.
    /// 
    /// This class is similar to the CustomCommand class, but that class
    /// has an ICommand.CanExecuteChanged implementation that allows
    /// manual updates.
    /// 
    /// If you are converting back-end code to use MVVM,
    /// this may be the easier of the two ICommand implementations
    /// to use.
    /// </remarks>
    public sealed class BasicCommand : ICommand
    {
        public BasicCommand()
        {
            ExecuteHandler = () => { };
            CanExecuteHandler = () => true;
        }

        public BasicCommand(Action executeAction)
        {
            ExecuteHandler = executeAction;
            CanExecuteHandler = () => true;
        }

        public BasicCommand(Action executeAction, Func<bool> canExecuteFunc)
        {
            ExecuteHandler = executeAction;
            CanExecuteHandler = canExecuteFunc;
        }

        public bool CanExecute(object unused)
        {
            var canExecute = CanExecuteHandler;

            if (canExecute != null)
            {
                return canExecute.Invoke();
            }
            else
            {
                return true;
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void Execute(object unused)
        {
            var execute = ExecuteHandler;

            if (execute != null)
            {
                execute.Invoke();
            }
        }

        /// <summary>
        /// Delegate for ICommand.CanExecute
        /// </summary>
        public Func<bool> CanExecuteHandler
        {
            get;
            set;
        }

        /// <summary>
        /// Delegate for ICommand.Execute
        /// </summary>
        public Action ExecuteHandler
        {
            get;
            set;
        }
    }
}
