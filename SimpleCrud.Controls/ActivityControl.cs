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
    [TemplatePart(Name = PART_ActiveDialogContainer, Type = typeof(Grid))]
    [TemplatePart(Name = PART_InactiveDialogsContainer, Type = typeof(Grid))]
    public sealed class ActivityControl : ContentControl
    {
        #region Constants
        private const string PART_ActiveDialogContainer = "PART_ActiveDialogContainer";
        private const string PART_InactiveDialogsContainer = "PART_InactiveDialogsContainer";
        #endregion

        #region Dependency properties declarations

        public static readonly DependencyProperty JobDataContextProperty =
            DependencyProperty.Register(nameof(JobDataContext), typeof(object), typeof(ActivityControl), new PropertyMetadata(null));



        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            ActiveDialogContainer = GetTemplateChild(PART_ActiveDialogContainer) as Grid;
            InActiveDialogsContainer = GetTemplateChild(PART_InactiveDialogsContainer) as Grid;
        }

        public Grid ActiveDialogContainer;
        public Grid InActiveDialogsContainer;

        private static void AddDialog(ActivityControl activity, ProgressControl progress)
        {
            if (activity.ActiveDialogContainer is null)
            {
                throw new InvalidOperationException("Active progress container could not be found.");
            }

            if (activity.InActiveDialogsContainer is null)
            {
                throw new InvalidOperationException("Inactive progress container could not be found.");
            }

            //activity.StoreFocus();

            // if there's already an active progress, move to the background
            var activeDialog = activity.ActiveDialogContainer.Children.OfType<ProgressControl>().SingleOrDefault();
            if (activeDialog != null)
            {
                activity.ActiveDialogContainer.Children.Remove(activeDialog);
                activity.InActiveDialogsContainer.Children.Add(activeDialog);
            }

            activity.ActiveDialogContainer.Children.Add(progress); 

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
