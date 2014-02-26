// Copyright (c) 2013, 2014 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

using NUnit.Framework;
using KSMVVM.WPF.Testing;
using KSMVVM.WPF.ViewModel;

namespace KSMVVM.WPF.Tests.Examples
{
    [TestFixture]
    public class ViewModelTests
    {
        private sealed class FirstRunViewModel : ViewModelBase
        {
            public FirstRunViewModel(IAppNavigationService nav)
            {
                Nav = nav;
                
                Start = new BasicCommand();
                Start.ExecuteHandler = () =>
                {
                    Nav.Navigate(() => new HomePage());
                };
                
                Cancel = new BasicCommand();
                Cancel.ExecuteHandler = () =>
                {
                    Cancelling = true;
                };
            }
            
            public BasicCommand Start { get; private set; }
            public BasicCommand Cancel { get; private set; }
            public IAppNavigationService Nav { get; private set; }
            
            public bool Cancelling
            {
                get
                {
                    return cancelling;
                }
                set
                {
                    if (cancelling != value)
                    {
                        cancelling = value;
                        OnPropertyChanged("Cancelling");
                    }
                }
            }
            
            private bool cancelling;
        }
        
        private sealed class HomePage : Page
        {
            public HomePage()
            {
                // The 'real' HomePage would do some undesired
                // UI manipulation if it was real. To simulate this,
                // its constructor just throws an exception.
                throw new NotImplementedException();
            }
        }
        
        [Test]
        public void StartCommandTest()
        {
            MockAppNavigationService nav = new MockAppNavigationService();
            var target = new FirstRunViewModel(nav);
            
            target.Start.Execute(null);
            Assert.IsTrue(nav.ReceivedRequestFor<HomePage>());
        }
        
        [Test]
        public void CancelCommandTest()
        {
            MockAppNavigationService nav = new MockAppNavigationService();
            var target = new FirstRunViewModel(nav);
            target.Cancel.Execute(null);
            Assert.IsTrue(target.Cancelling);
        }
    }
}
