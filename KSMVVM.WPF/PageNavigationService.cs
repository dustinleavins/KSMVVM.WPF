﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace KSMVVM.WPF
{
    /// <summary>
    /// Implementation of IAppNavigationService that
    /// use NavigationService property of a Page instance
    /// for navigation.
    /// </summary>
    public sealed class PageNavigationService : IAppNavigationService
    {
        public PageNavigationService(Page page)
        {
            CurrentPage = page;
        }

        public Page CurrentPage
        {
            get;
            private set;
        }

        public void Navigate<TPage>(Func<TPage> page) where TPage : Page
        {
            CurrentPage.NavigationService.Navigate(page.Invoke());
        }

        public void GoBack()
        {
            CurrentPage.NavigationService.GoBack();
        }
    }
}
