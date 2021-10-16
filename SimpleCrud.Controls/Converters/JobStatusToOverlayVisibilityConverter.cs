using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using SimpleCrud.Infrastructure.Job;

namespace SimpleCrud.Controls.Converters
{
    public sealed class JobStatusToOverlayVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            JobCompletionStatus status = (JobCompletionStatus)value;
            if (status == JobCompletionStatus.Default) 
                return Visibility.Collapsed;
            return Visibility.Visible;               
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}