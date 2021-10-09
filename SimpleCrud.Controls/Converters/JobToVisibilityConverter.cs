using System;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;

namespace SimpleCrud.Controls.Converters
{
    public class JobToVisibilityConverter : IMultiValueConverter
    {
        public static Visibility Visible = Visibility.Visible;
        public static Visibility InVisible = Visibility.Hidden;
        
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            JobState state = Deconstruct(values);
            if (state.IsSuccessfullyCompleted || state.IsCanceled)
                return InVisible;
            if (state.IsNotCompleted || state.IsFaulted)
                return Visible;
            return InVisible;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private JobState Deconstruct(object[] bindings) => new JobState(((bool)bindings[0]), ((bool)bindings[1]), ((bool)bindings[2]), ((bool)bindings[3]));

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => null;
    }

    internal struct JobState
    {
        public bool IsNotCompleted { get; }
        public bool IsSuccessfullyCompleted { get; }
        public bool IsCanceled { get; }
        public bool IsFaulted { get; }

        internal JobState(bool isNotCompleted, bool isSuccessfullyCompleted, bool isCanceled, bool isFaulted)
        {
            IsNotCompleted = isNotCompleted;
            IsSuccessfullyCompleted = isSuccessfullyCompleted;
            IsCanceled = isCanceled;
            IsFaulted = isFaulted;
        }
    }
}