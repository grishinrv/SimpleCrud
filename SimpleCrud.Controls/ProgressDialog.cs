using System.Windows;
using System.Windows.Controls;

namespace SimpleCrud.Controls
{
    public sealed class ProgressDialog : Control
    {
        static ProgressDialog()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ProgressDialog), new FrameworkPropertyMetadata(typeof(ProgressDialog)));
        }
    }
}