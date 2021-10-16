using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace SimpleCrud.Controls.Converters
{
    public sealed class VisibilityReverseConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is Visibility visibility)
            {
                switch (visibility)
                {
                    case Visibility.Visible:
                        return Visibility.Hidden;
                    case Visibility.Hidden:
                        return Visibility.Visible;
                    case Visibility.Collapsed:
                        return Visibility.Visible;
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => null;
    }
}