using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.ValueBoxes;

namespace SimpleCrud.Controls
{
    [TemplatePart(Name = PART_CloseButton, Type = typeof(Button))]
    [TemplatePart(Name = PART_ErrorTextBlock, Type = typeof(TextBlock))]
    public sealed class ProgressControl : Control
    {
        public event Action OnShown;
        public event Action OnHidden;
        static ProgressControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProgressControl), new FrameworkPropertyMetadata(typeof(ProgressControl)));
        }

        private void IsIsProgressChanged(bool isInProgress)
        {
            if (isInProgress)
                OnShown?.Invoke();
            else
                OnHidden?.Invoke();
        }
        
        private static void IsInProgressChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            bool isInProgress = (bool)e.NewValue;
            ProgressControl source = d as ProgressControl;
            source?.IsIsProgressChanged(isInProgress);
        }

        #region Constants
        private const string PART_CloseButton = "PART_CloseButton";
        private const string PART_ErrorTextBlock = "PART_ErrorTextBlock";
        #endregion

        #region Dependency props define

        /// <summary>Identifies the <see cref="DialogButtonFontSize"/> dependency property.</summary>
        public static readonly DependencyProperty DialogButtonFontSizeProperty
            = DependencyProperty.Register(nameof(DialogButtonFontSize),
                typeof(double),
                typeof(ProgressControl),
                new PropertyMetadata(SystemFonts.MessageFontSize));

        public static readonly DependencyProperty OperationProperty =
            DependencyProperty.Register(nameof(Operation), typeof(string), typeof(ProgressControl),
                new PropertyMetadata("Operation"));

        public static readonly DependencyProperty ErrorProperty =
            DependencyProperty.Register(nameof(Error), typeof(string), typeof(ProgressControl),
                new PropertyMetadata(string.Empty));

        public static readonly DependencyProperty IsInProgressProperty =
            DependencyProperty.Register(nameof(IsInProgress), typeof(bool), typeof(ProgressControl),
                new FrameworkPropertyMetadata(BooleanBoxes.TrueBox, IsInProgressChangedCallback));
        
        public static readonly DependencyProperty IsCompletedProperty =
            DependencyProperty.Register(nameof(IsCompleted), typeof(bool), typeof(ProgressControl),
                new PropertyMetadata(BooleanBoxes.FalseBox));

        public static readonly DependencyProperty CompletedWithErrorProperty =
            DependencyProperty.Register(nameof(CompletedWithError), typeof(bool), typeof(ProgressControl),
                new PropertyMetadata(BooleanBoxes.FalseBox));

        #endregion

        #region Dependency props accessors

        /// <summary>
        /// Gets or sets the font size of any dialog buttons.
        /// </summary>
        public double DialogButtonFontSize
        {
            get => (double)this.GetValue(DialogButtonFontSizeProperty);
            set => this.SetValue(DialogButtonFontSizeProperty, value);
        }

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