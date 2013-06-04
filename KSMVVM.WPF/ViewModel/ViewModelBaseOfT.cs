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
        public ViewModelBase()
        {
        }

        public ViewModelBase(T model)
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
                return model;
            }
            set
            {
                if (!model.Equals(value))
                {
                    model = value;
                    OnPropertyChanged("Model");
                }
            }
        }

        /// <summary>
        /// Underlying backing field for ViewModelBase&lt;T&gt;.Model.
        /// </summary>
        protected T model;
    }
}
