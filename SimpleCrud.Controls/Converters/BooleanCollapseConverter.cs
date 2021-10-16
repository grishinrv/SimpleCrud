using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SimpleCrud.Controls.Converters
{
    public sealed  class BooleanCollapseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is bool isVisible && isVisible)
            {
                return Visibility.Visible;
            }
            return Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}