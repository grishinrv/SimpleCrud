using System.Windows;

namespace SimpleCrud.Controls.Converters
{
    public sealed class JobStatusToVisibilityConverter : JobStatusToDialogStateConverter
    {
        protected override object GetResultFromDialogState(DialogState state)
        {
            if (state == DialogState.Closed)
                return Visibility.Collapsed;
            return Visibility.Visible;
        }
    }
}