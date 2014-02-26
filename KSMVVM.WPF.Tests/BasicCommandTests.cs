// Copyright (c) 2013, 2014 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Windows.Input;
using NUnit.Framework;

namespace KSMVVM.WPF.Tests
{
    [TestFixture]
    public class BasicCommandTests
    {
        [Test]
        public void ExecuteTest()
        {
            bool ranCommand = false;
            ICommand target = new BasicCommand(
                () =>
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
            ICommand target = new BasicCommand(
                () => {},
                
                () =>
                {
                    ranCommand = true;
                    return true;
                });
            
            Assert.IsTrue(target.CanExecute(null));
            Assert.IsTrue(ranCommand);
        }
    }
}
