// Copyright (c) 2013, 2014 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KSMVVM.WPF.Messaging;

namespace KSMVVM.WPF.Tests
{
    [TestFixture]
    public class BasicMessengerTests
    {
        [Test]
        public void SendTest()
        {
            BasicMessenger target = new BasicMessenger();
            const string messageId = "test";
            bool calledAction = false;

            target.Register(messageId, () => { calledAction = true; });
            target.Send(messageId);

            Assert.IsTrue(calledAction);

            calledAction = false;
            target.Unregister(messageId);
            target.Send(messageId);

            Assert.IsFalse(calledAction);

        }
    }
}
