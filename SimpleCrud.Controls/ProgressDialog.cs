using System.Windows;
using System.Windows.Input;
using MahApps.Metro.ValueBoxes;

namespace SimpleCrud.Controls
{
    public sealed partial class ProgressDialog : BaseActivityDialog
    {
        static ProgressDialog()
        {
            VisibilityProperty.OverrideMetadata(typeof(ProgressDialog), new FrameworkPropertyMetadata(Visibility.Hidden));
        }

        public ProgressDialog()
        {
            InitializeComponent();
        }

        private void IsIsProgressChanged(bool isInProgress)
        {
            // if (!isInProgress)
            // {
            //     bool isSuccessful = string.IsNullOrWhiteSpace((string)GetValue(ErrorTextProperty));
            //     if (isSuccessful && (bool)GetValue(AutoCloseOnSuccessProperty))
            //     {
            //         SetValue(VisibilityProperty, Visibility.Hidden);
            //         // SetValue(ShowCancelButtonProperty, BooleanBoxes.FalseBox);
            //     }
            // }
        }

        private static void ShowProgressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool isInProgress = (bool)e.NewValue;
            ProgressDialog source = d as ProgressDialog;
            source?.IsIsProgressChanged(isInProgress);
        }


        #region Dependency props define

        public static readonly DependencyProperty ProcessErrorCommandProperty = DependencyProperty.Register(
            nameof(ProcessErrorCommand), typeof(ICommand), typeof(ProgressDialog),
            new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty ProcessErrorCommandParameterProperty = DependencyProperty.Register(
            nameof(ProcessErrorCommandParameter), typeof(object), typeof(ProgressDialog),
            new PropertyMetadata(default(object)));

        public static readonly DependencyProperty ProcessErrorButtonTextProperty = DependencyProperty.Register(
            nameof(ProcessErrorButtonText), typeof(string), typeof(ProgressDialog),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ErrorTextProperty =
            DependencyProperty.Register(nameof(ErrorText), typeof(string), typeof(ProgressDialog),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            nameof(Progress), typeof(double), typeof(ProgressDialog), new PropertyMetadata(default(double)));

        public static readonly DependencyProperty ShowProgressAnimationProperty =
            DependencyProperty.Register(nameof(ShowProgressAnimation), typeof(bool), typeof(ProgressDialog),
                new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, ShowProgressChanged));

        public static readonly DependencyProperty ShowCancelButtonProperty = DependencyProperty.Register(
            nameof(ShowCancelButton), typeof(bool), typeof(ProgressDialog), new PropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(
            nameof(CancelCommand), typeof(ICommand), typeof(ProgressDialog), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty AutoCloseOnSuccessProperty = DependencyProperty.Register(
            nameof(AutoCloseOnSuccess), typeof(bool), typeof(ProgressDialog),
            new PropertyMetadata(BooleanBoxes.FalseBox));

        #endregion

        #region Dependency props accessors

        public ICommand ProcessErrorCommand
        {
            get { return (ICommand)GetValue(ProcessErrorCommandProperty); }
            set { SetValue(ProcessErrorCommandProperty, value); }
        }

        public object ProcessErrorCommandParameter
        {
            get { return (object)GetValue(ProcessErrorCommandParameterProperty); }
            set { SetValue(ProcessErrorCommandParameterProperty, value); }
        }

        public string ProcessErrorButtonText
        {
            get { return (string)GetValue(ProcessErrorButtonTextProperty); }
            set { SetValue(ProcessErrorButtonTextProperty, value); }
        }

        public string ErrorText
        {
            get { return (string)GetValue(ErrorTextProperty); }
            set { SetValue(ErrorTextProperty, value); }
        }

        public double Progress
        {
            get { return (double)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }

        public bool ShowProgressAnimation
        {
            get { return (bool)GetValue(ShowProgressAnimationProperty); }
            set { SetValue(ShowProgressAnimationProperty, BooleanBoxes.Box(value)); }
        }

        public bool ShowCancelButton
        {
            get { return (bool)GetValue(ShowCancelButtonProperty); }
            set { SetValue(ShowCancelButtonProperty, value); }
        }

        public ICommand CancelCommand
        {
            get { return (ICommand)GetValue(CancelCommandProperty); }
            set { SetValue(CancelCommandProperty, value); }
        }
        public bool AutoCloseOnSuccess
        {
            get { return (bool)GetValue(AutoCloseOnSuccessProperty); }
            set { SetValue(AutoCloseOnSuccessProperty, BooleanBoxes.Box(value)); }
        }

        #endregion
    }
}