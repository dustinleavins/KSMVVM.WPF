// Copyright (c) 2013 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace KSMVVM.WPF
{
    /// <summary>
    /// Interface for classes implementing Page navigation functionality.
    /// </summary>
    public interface IAppNavigationService
    {
        /// <summary>
        /// Navigates to a Page by invoking a function.
        /// </summary>
        /// <param name="page">
        /// Function returning a Page instance
        /// </param>
        void Navigate<TPage>(Func<TPage> page) where TPage : Page;

        /// <summary>
        /// Navigates to the previous page.
        /// </summary>
        void GoBack();

        /// <summary>
        /// Gets the current page.
        /// </summary>
        Page CurrentPage { get; }
    }
}
