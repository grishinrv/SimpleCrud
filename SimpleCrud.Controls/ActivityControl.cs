using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCrud.Controls
{
    /// <summary>
    /// A form (tab) template, with support of async operations (ui-notifying) and dialogs.
    /// </summary>
    [TemplatePart(Name = PART_DialogContainer, Type = typeof(Grid))]
    [TemplatePart(Name = PART_ProgressViewContainer, Type = typeof(Grid))]
    public sealed class ActivityControl : ContentControl
    {
        static ActivityControl()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ActivityControl), new FrameworkPropertyMetadata(typeof(ActivityControl)));
        }
        
        #region Constants
        private const string PART_DialogContainer = "PART_DialogContainer";
        private const string PART_ProgressViewContainer = "PART_ProgressViewContainer";
        #endregion

        #region Dependency properties declarations

        public static readonly DependencyProperty JobDataContextProperty =
            DependencyProperty.Register(nameof(JobDataContext), typeof(object), typeof(ActivityControl), new FrameworkPropertyMetadata(new PropertyChangedCallback(OnJobDataContextChanged), null));

        #endregion


        #region CallBacks

        private static void OnJobDataContextChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            // AddDialog todo
        }

        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _dialogContainer = GetTemplateChild(PART_DialogContainer) as Grid;
            _progressViewContainer = GetTemplateChild(PART_ProgressViewContainer) as Grid;
        }

        private Grid _dialogContainer;
        private Grid _progressViewContainer;

        #region  Dependency properties accessors

        public object JobDataContext
        {
            get { return (object)GetValue(JobDataContextProperty); }
            set { SetValue(JobDataContextProperty, value); }
        }

        #endregion
    }
}
