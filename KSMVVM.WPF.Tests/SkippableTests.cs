using System;
using NUnit.Framework;
using KSMVVM.WPF.Testing;

namespace KSMVVM.WPF.Tests
{
    [TestFixture]
    public class SkippableTests
    {
        [Test]
        public void DoTest()
        {
            bool skippableRan = false;
            Skippable.Do(() =>
                         {
                             skippableRan = true;
                         });
            
            Assert.IsTrue(skippableRan);
        }
        
        [Test]
        [ExpectedException(typeof(ApplicationException))]
        public void DoThrowExceptionTest()
        {
            Skippable.Do(() =>
                         {
                             throw new ApplicationException();
                         });
        }
        
        [Test]
        public void SkipDoTest()
        {
            using (Skippable.Skip())
            {
                Skippable.Do(() =>
                             {
                                 throw new ApplicationException();
                             });
            }
            
            bool skippableRan = false;
            Skippable.Do(() =>
                         {
                             skippableRan = true;
                         });
            
            Assert.IsTrue(skippableRan);
        }
    }
}
