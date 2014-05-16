using System;
using System.ComponentModel;
using System.Linq.Expressions;
using FMUtility.Core.Extensions;

namespace FMUtility.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void RaisePropertyChanged<T>(Expression<Func<T>> property)
        {
            RaisePropertyChanged(property.GetPropertyName());
        }

        private void RaisePropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}