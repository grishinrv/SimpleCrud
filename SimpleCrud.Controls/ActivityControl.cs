using System.Windows;
using System.Windows.Controls;
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

        public ProgressContext ProgressContext { get; set; }

    }
}
