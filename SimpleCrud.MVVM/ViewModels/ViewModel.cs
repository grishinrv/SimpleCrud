using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace SimpleCrud.MVVM.ViewModels
{
    public abstract class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnSet<T>(ref T field, T newVal, Action<T, T> onChangedAction = null, [CallerMemberName] string propertyName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, newVal))
            {
                var oldVal = field;
                field = newVal;
                OnPropertyChanged(propertyName);
                onChangedAction?.Invoke(oldVal, newVal);
            }
        }
    }
}
