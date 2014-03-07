// Copyright (c) 2013, 2014 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Windows.Input;
using NUnit.Framework;

namespace KSMVVM.WPF.Tests
{
    [TestFixture]
    public class CustomCommandTests
    {
        [Test]
        public void ExecuteTest()
        {
            bool ranCommand = false;
            ICommand target = new CustomCommand(
                (param) =>
                {
                    ranCommand = true;
                });
            
            target.Execute(null);
            Assert.IsTrue(ranCommand);
        }
        
        [Test]
        public void CanExecuteTest()
        {
            bool ranCommand = false;
            ICommand target = new CustomCommand(
                (param) => {},
                
                (param) =>
                {
                    ranCommand = true;
                    return true;
                });
            
            Assert.IsTrue(target.CanExecute(null));
            Assert.IsTrue(ranCommand);
        }
        
        [Test]
        public void TriggerCanExecuteChangedTest()
        {
            bool triggeredUpdate = false;
            CustomCommand target = new CustomCommand();
            
            target.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                triggeredUpdate = true;
            };
            
            target.TriggerCanExecuteChanged();
            Assert.IsTrue(triggeredUpdate);
        }
        
        [Test]
        public void DefaultConstructorTest()
        {
            ICommand target = new CustomCommand();
            
            // These two method calls should not throw exceptions
            target.CanExecute(null);
            target.Execute(null);
        }
    }
}
