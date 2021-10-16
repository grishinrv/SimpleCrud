using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SimpleCrud.Controls.Converters
{
    public class VisibilityLogicAndMultiConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            foreach (var value in values)
            {
                Visibility visibility = (Visibility)value;
                if (visibility != Visibility.Visible)
                    return Visibility.Collapsed;
            }

            return Visibility.Visible;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => null;
    }
}