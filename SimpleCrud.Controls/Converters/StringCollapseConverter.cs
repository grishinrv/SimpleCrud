using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SimpleCrud.Controls.Converters
{
    public class StringCollapseConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string stringValue && !string.IsNullOrWhiteSpace(stringValue))
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}