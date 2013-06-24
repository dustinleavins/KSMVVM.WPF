// Copyright (c) 2013 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Windows.Controls;
using NUnit.Framework;
using KSMVVM.WPF.Testing;

namespace KSMVVM.WPF.Tests
{
    [TestFixture]
    public class MockAppNavigationServiceTests
    {
        private MockAppNavigationService target;
        
        [SetUp]
        public void SetUp()
        {
            target = new MockAppNavigationService();
        }
        
        [Test]
        public void CurrentPageTest()
        {
            Assert.IsNull(target.CurrentPage);
        }
        
        [Test]
        public void GoBackTest()
        {
            target.GoBack();
            Assert.AreEqual(1, target.GoBackRequestCount);
            Assert.IsTrue(target.ReceivedGoBackRequest);
            
            target.GoBack();
            target.GoBack();
            target.GoBack();
            Assert.AreEqual(4, target.GoBackRequestCount);
            
            target.ResetAccessData();
            Assert.AreEqual(0, target.GoBackRequestCount);
            Assert.IsFalse(target.ReceivedGoBackRequest);
        }
        
        [Test]
        public void NavigateTest()
        {
            target.Navigate(() => new ThrowsExceptionPage());
            
            Assert.AreEqual(1, target.RequestCount);
            Assert.AreEqual(1, target.RequestCountFor(typeof(ThrowsExceptionPage)));
            Assert.AreEqual(1, target.RequestCountFor<ThrowsExceptionPage>());
            
            Assert.IsTrue(target.ReceivedRequest());
            Assert.IsTrue(target.ReceivedRequestFor<ThrowsExceptionPage>());
            Assert.IsTrue(target.ReceivedRequestFor(typeof(ThrowsExceptionPage)));
            Assert.IsFalse(target.ReceivedRequestFor<SecondaryPage>());
            Assert.IsFalse(target.ReceivedRequestFor(typeof(SecondaryPage)));
            
            target.Navigate(() => new ThrowsExceptionPage());
            target.Navigate(() => new ThrowsExceptionPage());
            target.Navigate(() => new ThrowsExceptionPage());
            target.Navigate(() => new SecondaryPage());
            
            Assert.AreEqual(5, target.RequestCount);
            Assert.AreEqual(4, target.RequestCountFor(typeof(ThrowsExceptionPage)));
            Assert.AreEqual(4, target.RequestCountFor<ThrowsExceptionPage>());
            
            Assert.IsTrue(target.ReceivedRequestFor<SecondaryPage>());
            Assert.IsTrue(target.ReceivedRequestFor(typeof(SecondaryPage)));
            Assert.AreEqual(1, target.RequestCountFor(typeof(SecondaryPage)));
            Assert.AreEqual(1, target.RequestCountFor<SecondaryPage>());
            
            target.ResetAccessData();
            Assert.IsFalse(target.ReceivedRequest());
            Assert.IsFalse(target.ReceivedRequestFor<ThrowsExceptionPage>());
            Assert.IsFalse(target.ReceivedRequestFor<SecondaryPage>());
        }
        
        private class ThrowsExceptionPage : Page
        {
            public ThrowsExceptionPage()
            {
                throw new ApplicationException();
            }
        }
        
        private class SecondaryPage : Page
        {
            
        }
    }
}
