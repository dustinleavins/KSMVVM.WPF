// Copyright (c) 2013, 2014 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using KSMVVM.WPF.ViewModel;

namespace KSMVVM.WPF.Tests
{
    [TestFixture]
    public sealed class ViewModelBaseTests
    {
        [Test]
        public void OnPropertyChangedStringTest()
        {
            bool propertyChanged = false;
            var target = new TargetViewModel();

            target.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "StringName")
                {
                    propertyChanged = true;
                }
                
            };

            target.StringName = "Test";
            Assert.IsTrue(propertyChanged);
        }

        [Test]
        public void OnPropertyChangedExpressionTest()
        {
            bool propertyChanged = false;
            var target = new TargetViewModel();

            target.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == "ExpressionName")
                {
                    propertyChanged = true;
                }

            };

            target.ExpressionName = "Test";
            Assert.IsTrue(propertyChanged);
        }

        private sealed class TargetViewModel : ViewModelBase
        {
            public string StringName
            {
                get
                {
                    return stringName;
                }
                set
                {
                    if (!string.Equals(stringName, value, StringComparison.Ordinal))
                    {
                        stringName = value;
                        OnPropertyChanged("StringName");
                    }
                }
            }

            public string ExpressionName
            {
                get
                {
                    return expressionName;
                }
                set
                {
                    if (!string.Equals(expressionName, value, StringComparison.Ordinal))
                    {
                        expressionName = value;
                        OnPropertyChanged((TargetViewModel t) => t.ExpressionName);
                    }
                }
            }

            private string stringName;
            private string expressionName;
        }
    }
}
