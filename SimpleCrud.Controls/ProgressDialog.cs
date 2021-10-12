using System.CodeDom;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCrud.Controls
{
    [TemplatePart(Name = PART_ProgressBox, Type = typeof(ProgressControl))]
    public sealed class ProgressDialog : Control
    {
        private const string PART_ProgressBox = "PART_ProgressBox";
        
        public static readonly DependencyProperty PropertyTypeProperty = DependencyProperty.Register(
            nameof(IsDialogShown), typeof(bool), typeof(ProgressDialog), new PropertyMetadata(default(bool)));

        static ProgressDialog()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProgressDialog), new FrameworkPropertyMetadata(typeof(ProgressDialog)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _progress = GetTemplateChild(PART_ProgressBox) as ProgressControl;
        }

        private ProgressControl _progress; 
        
        public bool IsDialogShown
        {
            get { return (bool)GetValue(PropertyTypeProperty); }
            set { SetValue(PropertyTypeProperty, value); }
        }
    }
}