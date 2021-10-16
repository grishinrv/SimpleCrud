using System;
using System.Globalization;
using System.Windows.Data;
using SimpleCrud.MVVM;

namespace SimpleCrud.Controls.Converters
{
    public class JobStatusToDialogStateConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            JobCompletionStatus status = (JobCompletionStatus)values[0];
            bool autoClose = false;
            if (values[1] is bool close)
                autoClose = close;
            
            switch (status)
            {
                case JobCompletionStatus.None:
                    return GetResultFromDialogState(DialogState.Closed);
                case JobCompletionStatus.InProgress:
                    return GetResultFromDialogState(DialogState.PerformingJob);
                case JobCompletionStatus.CompetedSuccessfully:
                    if (autoClose)
                        return GetResultFromDialogState(DialogState.Closed);
                    return GetResultFromDialogState(DialogState.WaitingForUserDecision);
                case JobCompletionStatus.CompetedWithError:
                    return GetResultFromDialogState(DialogState.WaitingForUserDecision);
                default:
                    throw new NotImplementedException($"{status} is not implemented!");
            }
        }

        protected virtual object GetResultFromDialogState(DialogState state)
        {
            return state;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => null;
    }
}