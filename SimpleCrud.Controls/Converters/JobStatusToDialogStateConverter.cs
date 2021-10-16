using System;
using System.Globalization;
using System.Windows.Data;
using SimpleCrud.Controls.Components;
using SimpleCrud.Infrastructure.Job;

namespace SimpleCrud.Controls.Converters
{
    public sealed class JobStatusToDialogStateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            JobCompletionStatus status = (JobCompletionStatus)values[0];
            bool autoClose = false;
            if (values[1] is bool close)
                autoClose = close;
            
            switch (status)
            {
                case JobCompletionStatus.Default:
                    return DialogState.Closed;
                case JobCompletionStatus.InProgress:
                    return DialogState.PerformingJob;
                case JobCompletionStatus.CompetedSuccessfully:
                    if (autoClose)
                        return DialogState.Closed;
                    return DialogState.WaitingForUserDecision;
                case JobCompletionStatus.CompetedWithError:
                    return DialogState.WaitingForUserDecision;
                default:
                    throw new NotImplementedException($"{status} is not implemented!");
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => null;
    }
}