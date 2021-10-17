using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SimpleCrud.Controls.Components;

namespace SimpleCrud.Controls
{
    /// <summary>
    /// A form (tab) template, with support of async operations (ui-notifying) and dialogs.
    /// </summary>
    [TemplatePart(Name = PART_DialogContainer, Type = typeof(Grid))]
    [TemplatePart(Name = PART_ProgressDialog, Type = typeof(ProgressDialog))]
    public sealed class ActivityControl : ContentControl
    {
        static ActivityControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ActivityControl), new FrameworkPropertyMetadata(typeof(ActivityControl)));
        }
        
        #region Constants
        private const string PART_DialogContainer = "PART_DialogContainer";
        private const string PART_ProgressDialog = "PART_ProgressDialog";
        #endregion
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _dialogContainer = GetTemplateChild(PART_DialogContainer) as Grid;
        }

        private Grid _dialogContainer;

        public static readonly DependencyProperty ProgressContextProperty = DependencyProperty.Register(
            nameof(ProgressContext), typeof(ProgressContext), typeof(ActivityControl), 
            new FrameworkPropertyMetadata(default(ProgressContext), OnProgressContextAssigned));

        private static void OnProgressContextAssigned(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ProgressContext context = e.NewValue as ProgressContext;
            if (context != null)
            {
                Binding contextBinding = new Binding
                {
                    Source = d, 
                    Mode = BindingMode.OneWay, 
                    UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged,
                    Path = new PropertyPath("DataContext")
                };

                context.SetBinding(DataContextProperty, contextBinding);
            }
        }

        public ProgressContext ProgressContext
        {
            get { return (ProgressContext)GetValue(ProgressContextProperty); }
            set { SetValue(ProgressContextProperty, value); }
        }

    }
}
