using System.CodeDom;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.ValueBoxes;

namespace SimpleCrud.Controls
{
    [TemplatePart(Name = PART_ProgressBox, Type = typeof(ProgressDialog))]
    public sealed class ProgressView : Control
    {
        private const string PART_ProgressBox = "PART_ProgressBox";
        
        public static readonly DependencyProperty IsDialogShownProperty = DependencyProperty.Register(
            nameof(IsDialogShown), typeof(bool), typeof(ProgressView), new PropertyMetadata(BooleanBoxes.FalseBox));

        static ProgressView()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProgressView), new FrameworkPropertyMetadata(typeof(ProgressView)));
        }

        public override void OnApplyTemplate()
        {
            if (_progress != null)
            {
                _progress.OnHidden -= Hidden;
                _progress.OnShown -= Shown;
            }
            base.OnApplyTemplate();
            _progress = GetTemplateChild(PART_ProgressBox) as ProgressDialog;
            if (_progress != null)
            {
                _progress.OnHidden += Hidden;
                _progress.OnShown += Shown;
            }
        }

        private ProgressDialog _progress;

        private void Hidden() => SetValue(ProgressView.IsDialogShownProperty, BooleanBoxes.FalseBox);

        private void Shown() => SetValue(ProgressView.IsDialogShownProperty, BooleanBoxes.TrueBox);

        public bool IsDialogShown
        {
            get { return (bool)GetValue(IsDialogShownProperty); }
            set { SetValue(IsDialogShownProperty, value); }
        }
    }
}