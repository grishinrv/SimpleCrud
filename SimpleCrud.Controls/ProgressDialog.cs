using System;
using System.Windows;
using System.Windows.Input;
using MahApps.Metro.ValueBoxes;
using SimpleCrud.Controls.KnownBoxes;
using SimpleCrud.Infrastructure.Job;
using SimpleCrud.Infrastructure.KnownBoxes;

namespace SimpleCrud.Controls
{
    public sealed partial class ProgressDialog : BaseActivityDialog
    {
        #region constructors

        static ProgressDialog()
        {
            VisibilityProperty.OverrideMetadata(typeof(ProgressDialog),
                new FrameworkPropertyMetadata(VisibilityBoxes.CollapsedBox));
        }

        public ProgressDialog()
        {
            InitializeComponent();
            PART_CloseButton.Click += PART_CloseButtonOnClick;
            PART_CancelButton.Click += PART_CancelButtonOnClick;
        }

        #endregion

        #region callbacks

        private void PART_CloseButtonOnClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            SetValue(JobStatusProperty, JobCompletionStatusBoxes.DefaultBox);
        }

        private void PART_CancelButtonOnClick(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            SetValue(JobStatusProperty, JobCompletionStatusBoxes.CancelledBox);
        }

        private static void OnJobStatusChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProgressDialog source = d as ProgressDialog;
            bool jobStatusAssigned = e.NewValue is JobCompletionStatus;
            if (!jobStatusAssigned || d == null)
                return;

            JobCompletionStatus jobStatus = (JobCompletionStatus)e.NewValue;
            switch (jobStatus)
            {
                case JobCompletionStatus.InProgress:
                    source.OnInProgress();
                    break;
                case JobCompletionStatus.CompetedSuccessfully:
                    source.OnSuccess();
                    break;
                case JobCompletionStatus.CompetedWithError:
                    source.OnError();
                    break;
                case JobCompletionStatus.Default:
                case JobCompletionStatus.Cancelled:
                    source.SetDefaultState();
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"{jobStatus} is not implemented!");
            }
        }

        private void SetDefaultState()
        {
            SetValue(IsJobInProgressProperty, BooleanBoxes.FalseBox);
            SetValue(VisibilityProperty, VisibilityBoxes.CollapsedBox);
            SetValue(IsJobInProgressProperty, BooleanBoxes.FalseBox);
            SetValue(ShowProcessErrorButtonProperty, BooleanBoxes.FalseBox);
            SetValue(ShowCloseButtonProperty, BooleanBoxes.FalseBox);
            SetValue(ShowCancelButtonProperty, BooleanBoxes.FalseBox);
            SetValue(ProgressProperty, DoubleBoxes.ZeroBox);
        }

        private void OnError()
        {
            SetValue(IsJobInProgressProperty, BooleanBoxes.FalseBox);
            bool hasProcessErrorCommand = GetValue(ProcessErrorCommandProperty) is ICommand;
            if (hasProcessErrorCommand)
                SetValue(ShowProcessErrorButtonProperty, BooleanBoxes.TrueBox);
            SetValue(ShowCloseButtonProperty, BooleanBoxes.TrueBox);
        }

        private void OnSuccess()
        {
            SetValue(IsJobInProgressProperty, BooleanBoxes.FalseBox);
            bool closeOnSuccess = (bool)GetValue(AutoCloseOnSuccessProperty);
            if (closeOnSuccess)
                SetValue(VisibilityProperty, VisibilityBoxes.CollapsedBox);
            else
                SetValue(ShowCloseButtonProperty, BooleanBoxes.TrueBox);
        }

        private void OnInProgress()
        {
            SetValue(VisibilityProperty, VisibilityBoxes.VisibleBox);
            SetValue(ShowCloseButtonProperty, BooleanBoxes.FalseBox);
            SetValue(IsJobInProgressProperty, BooleanBoxes.TrueBox);
            if ((bool)GetValue(JobCanBeCancelledProperty))
                SetValue(ShowCancelButtonProperty, BooleanBoxes.TrueBox);
            else
                SetValue(ShowCancelButtonProperty, BooleanBoxes.FalseBox);
        }

        #endregion

        #region Dependency props define

        public static readonly DependencyProperty JobStatusProperty = DependencyProperty.Register(
            nameof(JobStatus), typeof(JobCompletionStatus), typeof(ProgressDialog),
            new FrameworkPropertyMetadata(JobCompletionStatusBoxes.DefaultBox, OnJobStatusChanged));

        public static readonly DependencyProperty ProcessErrorCommandProperty = DependencyProperty.Register(
            nameof(ProcessErrorCommand), typeof(ICommand), typeof(ProgressDialog),
            new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty ProcessErrorButtonTextProperty = DependencyProperty.Register(
            nameof(ProcessErrorButtonText), typeof(string), typeof(ProgressDialog),
            new PropertyMetadata(default(string)));

        public static readonly DependencyProperty ErrorTextProperty =
            DependencyProperty.Register(nameof(ErrorText), typeof(string), typeof(ProgressDialog),
                new FrameworkPropertyMetadata(string.Empty));

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            nameof(Progress), typeof(double), typeof(ProgressDialog), new PropertyMetadata(default(double)));

        public static readonly DependencyProperty IsJobInProgressProperty =
            DependencyProperty.Register(nameof(IsJobInProgress), typeof(bool), typeof(ProgressDialog),
                new FrameworkPropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty JobCanBeCancelledProperty = DependencyProperty.Register(
            nameof(JobCanBeCancelled), typeof(bool), typeof(ProgressDialog),
            new PropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty ShowProcessErrorButtonProperty = DependencyProperty.Register(
            nameof(ShowProcessErrorButton), typeof(bool), typeof(ProgressDialog),
            new PropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty ShowCancelButtonProperty = DependencyProperty.Register(
            nameof(ShowCancelButton), typeof(bool), typeof(ProgressDialog),
            new PropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty ShowCloseButtonProperty = DependencyProperty.Register(
            nameof(ShowCloseButton), typeof(bool), typeof(ProgressDialog),
            new PropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty AutoCloseOnSuccessProperty = DependencyProperty.Register(
            nameof(AutoCloseOnSuccess), typeof(bool), typeof(ProgressDialog),
            new FrameworkPropertyMetadata(BooleanBoxes.FalseBox));

        #endregion

        #region Dependency props accessors

        public JobCompletionStatus JobStatus
        {
            get { return (JobCompletionStatus)GetValue(JobStatusProperty); }
            set { SetValue(JobStatusProperty, JobCompletionStatusBoxes.Box(value)); }
        }

        public ICommand ProcessErrorCommand
        {
            get { return (ICommand)GetValue(ProcessErrorCommandProperty); }
            set { SetValue(ProcessErrorCommandProperty, value); }
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

        public bool IsJobInProgress
        {
            get { return (bool)GetValue(IsJobInProgressProperty); }
            set { SetValue(IsJobInProgressProperty, BooleanBoxes.Box(value)); }
        }

        public bool JobCanBeCancelled
        {
            get { return (bool)GetValue(JobCanBeCancelledProperty); }
            set { SetValue(JobCanBeCancelledProperty, BooleanBoxes.Box(value)); }
        }

        public bool ShowProcessErrorButton
        {
            get { return (bool)GetValue(ShowProcessErrorButtonProperty); }
            set { SetValue(ShowProcessErrorButtonProperty, BooleanBoxes.Box(value)); }
        }

        public bool ShowCancelButton
        {
            get { return (bool)GetValue(ShowCancelButtonProperty); }
            set { SetValue(ShowCancelButtonProperty, BooleanBoxes.Box(value)); }
        }

        public bool ShowCloseButton
        {
            get { return (bool)GetValue(ShowCloseButtonProperty); }
            set { SetValue(ShowCloseButtonProperty, BooleanBoxes.Box(value)); }
        }

        public bool AutoCloseOnSuccess
        {
            get { return (bool)GetValue(AutoCloseOnSuccessProperty); }
            set { SetValue(AutoCloseOnSuccessProperty, BooleanBoxes.Box(value)); }
        }

        #endregion
    }
}