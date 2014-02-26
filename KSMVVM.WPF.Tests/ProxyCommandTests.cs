// Copyright (c) 2014 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Windows.Input;
using NUnit.Framework;

namespace KSMVVM.WPF.Tests
{
    [TestFixture]
    public sealed class ProxyCommandTests
    {
        private ProxyCommand target;

        [SetUp]
        public void SetUp()
        {
            target = new ProxyCommand();
        }

        [Test]
        public void CanExecuteNullBackingCommandTest()
        {
            Assert.IsFalse(target.CanExecute(null));
        }

        [Test]
        public void CanExecuteTest()
        {
            ICommand backingCommand = new CustomCommand(
                (x) => { },

                (x) =>
                {
                    return x != null;
                });

            target.BackingCommand = backingCommand;
            Assert.IsTrue(target.CanExecute("Data"));
            Assert.IsFalse(target.CanExecute(null));
        }

        [Test]
        public void ExecuteNullBackingCommandTest()
        {
            // Ensure that a NullReferenceException doesn't get thrown
            target.Execute(null);
        }
        
        [Test]
        public void ExecuteTest()
        {
            bool valueToCheck = false;
            ICommand backingCommand = new CustomCommand(
                (x) =>
                {
                    valueToCheck = x != null;
                });
            
            target.BackingCommand = backingCommand;
            backingCommand.Execute("Data");
            Assert.IsTrue(valueToCheck);
            
            backingCommand.Execute(null);
            Assert.IsFalse(valueToCheck);
        }
    }
}
