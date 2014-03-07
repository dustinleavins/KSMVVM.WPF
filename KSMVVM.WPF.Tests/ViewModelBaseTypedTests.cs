﻿using System;
using NUnit.Framework;
using KSMVVM.WPF.ViewModel;

namespace KSMVVM.WPF.Tests
{
    [TestFixture]
    public class ViewModelBaseTypedTests
    {
        [Test]
        public void ModelTest()
        {
            bool propertyChanged = false;
            ViewModelBase<TargetStruct> target = new TargetViewModel();
            
            target.PropertyChanged += (sender, e) =>
            {
                propertyChanged = true;
            };
            
            target.Model = new TargetStruct() { Name = "Test String" };
            Assert.IsTrue(propertyChanged);
            Assert.AreEqual("Test String", target.Model.Name);
            
            // Property Update
            propertyChanged = false;
            target.Model = new TargetStruct() { Name = "Test String #2" };
            Assert.IsTrue(propertyChanged);
            Assert.AreEqual("Test String #2", target.Model.Name);
        }
        
        private sealed class TargetViewModel : ViewModelBase<TargetStruct>
        {
        }
        
        private struct TargetStruct
        {
            public String Name { get; set; }
        }
    }
}
