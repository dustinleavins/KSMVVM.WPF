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
            target.Execute("Data");
            Assert.IsTrue(valueToCheck);
            
            target.Execute(null);
            Assert.IsFalse(valueToCheck);
        }
        
        [Test]
        public void TriggerCanExecuteChangedTest()
        {
            bool triggeredChange = false;
            CustomCommand backingCommand = new CustomCommand();
            target.BackingCommand = backingCommand;
            
            target.CanExecuteChanged += (object sender, EventArgs e) =>
            {
                triggeredChange = true;
            };
            
            backingCommand.TriggerCanExecuteChanged();
            Assert.IsTrue(triggeredChange);
        }
        
        [Test]
        public void BackingCommandTest()
        {
            ICommand backingCommand = new CustomCommand();
            target.BackingCommand = backingCommand;
            Assert.IsNotNull(target.BackingCommand);
            
            target.BackingCommand = null;
            Assert.IsNull(target.BackingCommand);
            
            Assert.IsFalse(target.CanExecute(null));
            target.Execute(null);
        }
    }
}
