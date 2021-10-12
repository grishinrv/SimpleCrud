using System.CodeDom;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.ValueBoxes;

namespace SimpleCrud.Controls
{
    [TemplatePart(Name = PART_ProgressBox, Type = typeof(ProgressControl))]
    public sealed class ProgressDialog : Control
    {
        private const string PART_ProgressBox = "PART_ProgressBox";
        
        public static readonly DependencyProperty IsDialogShownProperty = DependencyProperty.Register(
            nameof(IsDialogShown), typeof(bool), typeof(ProgressDialog), new PropertyMetadata(BooleanBoxes.FalseBox));

        static ProgressDialog()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProgressDialog), new FrameworkPropertyMetadata(typeof(ProgressDialog)));
        }

        public override void OnApplyTemplate()
        {
            if (_progress != null)
            {
                _progress.OnHidden -= Hidden;
                _progress.OnShown -= Shown;
            }
            base.OnApplyTemplate();
            _progress = GetTemplateChild(PART_ProgressBox) as ProgressControl;
            if (_progress != null)
            {
                _progress.OnHidden += Hidden;
                _progress.OnShown += Shown;
            }
        }

        private ProgressControl _progress;

        private void Hidden() => SetValue(ProgressDialog.IsDialogShownProperty, BooleanBoxes.FalseBox);

        private void Shown() => SetValue(ProgressDialog.IsDialogShownProperty, BooleanBoxes.TrueBox);

        public bool IsDialogShown
        {
            get { return (bool)GetValue(IsDialogShownProperty); }
            set { SetValue(IsDialogShownProperty, value); }
        }
    }
}