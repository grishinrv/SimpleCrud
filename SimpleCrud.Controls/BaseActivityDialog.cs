using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace SimpleCrud.Controls
{
    public class BaseActivityDialog : ContentControl
    {
        #region dependency properties metadata
        
        public static readonly DependencyProperty TitleProperty
            = DependencyProperty.Register(nameof(Title),
                typeof(string),
                typeof(BaseMetroDialog),
                new PropertyMetadata(default(string)));
        
        public static readonly DependencyProperty DialogTitleFontSizeProperty
            = DependencyProperty.Register(nameof(DialogTitleFontSize),
                typeof(double),
                typeof(BaseMetroDialog),
                new PropertyMetadata(26D));
        
        public static readonly DependencyProperty DialogMessageFontSizeProperty
            = DependencyProperty.Register(nameof(DialogMessageFontSize),
                typeof(double),
                typeof(BaseMetroDialog),
                new PropertyMetadata(15D));

        public static readonly DependencyProperty DialogButtonFontSizeProperty
            = DependencyProperty.Register(nameof(DialogButtonFontSize),
                typeof(double),
                typeof(BaseMetroDialog),
                new PropertyMetadata(SystemFonts.MessageFontSize));

        #endregion

        #region dependency properties accessors
        public string? Title
        {
            get => (string?)this.GetValue(TitleProperty);
            set => this.SetValue(TitleProperty, value);
        }
        public double DialogMessageFontSize
        {
            get => (double)this.GetValue(DialogMessageFontSizeProperty);
            set => this.SetValue(DialogMessageFontSizeProperty, value);
        }
        public double DialogButtonFontSize
        {
            get => (double)this.GetValue(DialogButtonFontSizeProperty);
            set => this.SetValue(DialogButtonFontSizeProperty, value);
        }
        public double DialogTitleFontSize
        {
            get => (double)this.GetValue(DialogTitleFontSizeProperty);
            set => this.SetValue(DialogTitleFontSizeProperty, value);
        }
        #endregion
    }
}