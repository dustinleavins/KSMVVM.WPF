// Copyright (c) 2013 Dustin Leavins
// See the file 'LICENSE.txt' for copying permission.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KSMVVM.WPF.ViewModel
{
    /// <summary>
    /// Base class for View Models that contain a single model object.
    /// </summary>
    public abstract class ViewModelBase<T> : ViewModelBase
    {
        protected ViewModelBase()
        {
        }

        protected ViewModelBase(T model)
        {
            Model = model;
        }

        /// <summary>
        /// Model instance.
        /// </summary>
        public T Model
        {
            get
            {
                return modelData;
            }
            set
            {
                if (!modelData.Equals(value))
                {
                    modelData = value;
                    OnPropertyChanged("Model");
                }
            }
        }

        /// <summary>
        /// Underlying backing field for ViewModelBase&lt;T&gt;.Model.
        /// </summary>
        private T modelData;
    }
}
