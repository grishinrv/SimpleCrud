using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using SimpleCrud.Controls.Helpers;

namespace SimpleCrud.Controls.Converters
{
    public class DialogStateToVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            DialogState actualState = (DialogState)value;
            DialogState expectedState = ((DialogStateContainer)parameter).State;
            if (actualState == expectedState)
                return Visibility.Visible;
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) 
            => null;
    }
}