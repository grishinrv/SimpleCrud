using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.ValueBoxes;

namespace SimpleCrud.Controls
{
    [TemplatePart(Name = PART_CloseButton, Type = typeof(Button))]
    public sealed class ProgressViewControl : Control
    {
        #region Constants
        private const string PART_CloseButton = "PART_CloseButton";
        #endregion
        
        #region Dependency props define
        public static readonly DependencyProperty OperationProperty =
            DependencyProperty.Register(nameof(Operation), typeof(string), typeof(ProgressViewControl), new PropertyMetadata("Operation"));

        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register(nameof(Error), typeof(string), typeof(ProgressViewControl), new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty IsInProgressProperty =
            DependencyProperty.Register(nameof(IsInProgress), typeof(bool), typeof(ProgressViewControl), new PropertyMetadata(BooleanBoxes.TrueBox));

        public static readonly DependencyProperty IsCompletedProperty =
            DependencyProperty.Register(nameof(IsCompleted), typeof(bool), typeof(ProgressViewControl), new PropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty CompletedWithErrorProperty =
            DependencyProperty.Register(nameof(CompletedWithError), typeof(bool), typeof(ProgressViewControl), new PropertyMetadata(BooleanBoxes.FalseBox));
        #endregion

        #region Dependency props accessors
        public string Operation
        {
            get { return (string)GetValue(OperationProperty); }
            set { SetValue(OperationProperty, value); }
        }

        public string Error
        {
            get { return (string)GetValue(ErrorProperty); }
            set { SetValue(ErrorProperty, value); }
        }

        public bool IsInProgress
        {
            get { return (bool)GetValue(IsInProgressProperty); }
            set { SetValue(IsInProgressProperty, BooleanBoxes.Box(value)); }
        }

        public bool IsCompleted
        {
            get { return (bool)GetValue(IsCompletedProperty); }
            set { SetValue(IsCompletedProperty, BooleanBoxes.Box(value)); }
        }

        public bool CompletedWithError
        {
            get { return (bool)GetValue(CompletedWithErrorProperty); }
            set { SetValue(CompletedWithErrorProperty, BooleanBoxes.Box(value)); }
        }
        
        #endregion

    }
}
