﻿using System.Windows;
using System.Windows.Input;
using MahApps.Metro.ValueBoxes;

namespace SimpleCrud.Controls
{
    public enum DialogState
    {
        Closed = 0,
        PerformingJob = 1,
        WaitingForUserDecision = 2
    }

    public sealed partial class ProgressDialog : BaseActivityDialog
    {
        #region constructors

        static ProgressDialog()
        {
            VisibilityProperty.OverrideMetadata(typeof(ProgressDialog),
                new FrameworkPropertyMetadata(Visibility.Hidden));
        }

        public ProgressDialog()
        {
            InitializeComponent();
            PART_CloseButton.Click += CloseButtonClicked;
        }

        #endregion

        private void CloseButtonClicked(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            SetValue(VisibilityProperty, Visibility.Collapsed);
        }

        private void ActualizeState()
        {
            DialogState state;
            bool isInProgress = (bool)GetValue(IsJobInProgressProperty);
            bool hasError = false;
            bool autoClose = false;
            if (isInProgress)
                state = DialogState.PerformingJob;
            else
            {
                 hasError = !string.IsNullOrWhiteSpace((string)GetValue(ErrorTextProperty));
                 if (hasError)
                     state = DialogState.WaitingForUserDecision;
                else
                {
                    autoClose = (bool)GetValue(AutoCloseOnSuccessProperty);
                    if (autoClose)
                        state = DialogState.Closed;
                    else
                        state = DialogState.WaitingForUserDecision;
                }
            }

            SetValue(DialogStateProperty, state);
        }

        #region dependency properties callbacks

        private static void IsJobInProgressChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProgressDialog source = d as ProgressDialog;
            source.ActualizeState();
        }

        private static void OnErrorTextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProgressDialog source = d as ProgressDialog;
            source.ActualizeState();
        }

        private static void OnAutoCloseChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProgressDialog source = d as ProgressDialog;
            source.ActualizeState();
        }

        private static void OnDialogStateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProgressDialog source = d as ProgressDialog;
            DialogState newState = (DialogState)e.NewValue;
            if (newState == DialogState.Closed)
            {
                source.SetValue(VisibilityProperty, Visibility.Collapsed);
            }
        }

        #endregion

        #region Dependency props define

        public static readonly DependencyProperty DialogStateProperty = DependencyProperty.Register(
            nameof(DialogState), typeof(DialogState), typeof(ProgressDialog),
            new FrameworkPropertyMetadata(Controls.DialogState.Closed, OnDialogStateChanged));

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
                new FrameworkPropertyMetadata(string.Empty, OnErrorTextChanged));

        public static readonly DependencyProperty ProgressProperty = DependencyProperty.Register(
            nameof(Progress), typeof(double), typeof(ProgressDialog), new PropertyMetadata(default(double)));

        public static readonly DependencyProperty IsJobInProgressProperty =
            DependencyProperty.Register(nameof(IsJobInProgress), typeof(bool), typeof(ProgressDialog),
                new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, IsJobInProgressChanged));

        public static readonly DependencyProperty ShowCancelButtonProperty = DependencyProperty.Register(
            nameof(ShowCancelButton), typeof(bool), typeof(ProgressDialog),
            new PropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty CancelCommandProperty = DependencyProperty.Register(
            nameof(CancelCommand), typeof(ICommand), typeof(ProgressDialog), new PropertyMetadata(default(ICommand)));

        public static readonly DependencyProperty AutoCloseOnSuccessProperty = DependencyProperty.Register(
            nameof(AutoCloseOnSuccess), typeof(bool), typeof(ProgressDialog),
            new FrameworkPropertyMetadata(BooleanBoxes.FalseBox, OnAutoCloseChanged));

        #endregion

        #region Dependency props accessors

        public DialogState DialogState
        {
            get { return (DialogState)GetValue(DialogStateProperty); }
            set { SetValue(DialogStateProperty, value); }
        }

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

        public bool IsJobInProgress
        {
            get { return (bool)GetValue(IsJobInProgressProperty); }
            set { SetValue(IsJobInProgressProperty, BooleanBoxes.Box(value)); }
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