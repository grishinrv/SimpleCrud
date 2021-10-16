using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using SimpleCrud.Infrastructure.Job;

namespace SimpleCrud.Controls.Converters
{
    public class JobCancelButtonVisibilityConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {            
            JobCompletionStatus status = (JobCompletionStatus)values[0];
            bool jobCanBeCancelled = ((JobData)values[1]).IsCancellable;
            if (jobCanBeCancelled && status == JobCompletionStatus.InProgress)
                return Visibility.Visible;                
            return Visibility.Collapsed;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)=> null;
    }
}