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
            _activeDialogContainer = GetTemplateChild(PART_DialogContainer) as Grid;
            _progressViewContainer = GetTemplateChild(PART_ProgressViewContainer) as Grid;
        }

        private Grid _activeDialogContainer;
        private Grid _inActiveDialogsContainer;
        private Grid _inactiveProgressViewContainer;
        private Grid _progressViewContainer;

        private static void AddDialog(ActivityControl activity, ProgressControl progress)
        {
            if (activity._activeDialogContainer is null)
            {
                throw new InvalidOperationException("Active progress container could not be found.");
            }

            if (activity._inActiveDialogsContainer is null)
            {
                throw new InvalidOperationException("Inactive progress container could not be found.");
            }

            //activity.StoreFocus();

            // if there's already an active progress, move to the background
            var activeDialog = activity._activeDialogContainer.Children.OfType<ProgressControl>().SingleOrDefault();
            if (activeDialog != null)
            {
                activity._activeDialogContainer.Children.Remove(activeDialog);
                activity._inActiveDialogsContainer.Children.Add(activeDialog);
            }

            activity._activeDialogContainer.Children.Add(progress); 

            //activity.SetValue(MetroWindow.IsAnyDialogOpenPropertyKey, BooleanBoxes.TrueBox);
        }
        
        private static void ShowProgressView(ActivityControl activity, ProgressControl progress)
        {
            if (activity._progressViewContainer is null)
            {
                throw new InvalidOperationException("Progress container could not be found.");
            }

            if (activity._inactiveProgressViewContainer is null)
            {
                throw new InvalidOperationException("Inactive progress container could not be found.");
            }

            //activity.StoreFocus();

            // if there's already an active progress, move to the background
            var activeDialog = activity._progressViewContainer.Children.OfType<ProgressControl>().SingleOrDefault();
            if (activeDialog != null)
            {
                activity._progressViewContainer.Children.Remove(activeDialog);
                activity._inactiveProgressViewContainer.Children.Add(activeDialog);
            }

            activity._progressViewContainer.Children.Add(progress); 

            //activity.SetValue(MetroWindow.IsAnyDialogOpenPropertyKey, BooleanBoxes.TrueBox);
        }

        #region  Dependency properties accessors

        public object JobDataContext
        {
            get { return (object)GetValue(JobDataContextProperty); }
            set { SetValue(JobDataContextProperty, value); }
        }

        #endregion
    }
}
