using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;

namespace KSMVVM.WPF
{
    /// <summary>
    /// 'Custom' implementation of ICommand.
    /// </summary>
    /// <remarks>
    /// This is similar to the BasicCommand class, but with two major
    /// differences:
    /// <list type="bullet">
    /// <item>
    ///     <descripton>
    ///     BasicCommand implements ICommand.CanExecuteChanged with a hack
    ///     that may cause performance problems.
    ///     </descripton>
    /// </item>
    /// 
    /// <item>
    ///     <description>
    ///     CustomCommand requires delegates that can take an object as
    ///     a parameter.
    ///     </description>
    /// </item>
    /// </list>
    /// If you are writing new code (and not converting back-end code
    /// to MVVM), this is the recommended ICommand implementation to use.
    /// </remarks>
    public sealed class CustomCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        
        public CustomCommand()
        {
            ExecuteHandler = (param) => { };
            CanExecuteHandler = (param) => true;
        }
        
        public CustomCommand(Action<object> executeAction)
        {
            ExecuteHandler = executeAction;
            CanExecuteHandler = (param) => true;
        }

        public CustomCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            ExecuteHandler = executeAction;
            CanExecuteHandler = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            var canExecute = CanExecuteHandler;

            if (canExecute != null)
            {
                return canExecute.Invoke(parameter);
            }
            else
            {
                return true;
            }
        }

        public void Execute(object parameter)
        {
            var execute = ExecuteHandler;

            if (execute != null)
            {
                execute.Invoke(parameter);
            }
        }

        /// <summary>
        /// Delegate for ICommand.CanExecute
        /// </summary>
        public Func<object, bool> CanExecuteHandler
        {
            get;
            set;
        }

        /// <summary>
        /// Delegate for ICommand.Execute
        /// </summary>
        public Action<object> ExecuteHandler
        {
            get;
            set;
        }

        public void TriggerCanExecuteChanged()
        {
            var handler = CanExecuteChanged;

            if (handler != null)
            {
                handler(this, new EventArgs());
            }
        }
    }
}
