using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCrud.Controls
{
    [TemplatePart(Name = PART_ButtonsPanel, Type = typeof(ItemsControl))]
    public class BaseActivityDialog : ContentControl
    {
        private const string PART_ButtonsPanel = "PART_ButtonsPanel";

        static BaseActivityDialog()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseActivityDialog),
                new FrameworkPropertyMetadata(typeof(BaseActivityDialog)));
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _buttonsPanel = GetTemplateChild(PART_ButtonsPanel) as ItemsControl;
            List<Button> buttons = GetValue(ButtonsProperty) as List<Button>;
            StyleButtons(buttons);
        }

        private ItemsControl _buttonsPanel;

        #region dependency properties metadata

        public static readonly DependencyProperty TitleProperty
            = DependencyProperty.Register(nameof(Title),
                typeof(string),
                typeof(BaseActivityDialog),
                new FrameworkPropertyMetadata(default(string)));

        public static readonly DependencyProperty DialogTitleFontSizeProperty
            = DependencyProperty.Register(nameof(DialogTitleFontSize),
                typeof(double),
                typeof(BaseActivityDialog),
                new PropertyMetadata(26D));

        public static readonly DependencyProperty DialogMessageFontSizeProperty
            = DependencyProperty.Register(nameof(DialogMessageFontSize),
                typeof(double),
                typeof(BaseActivityDialog),
                new PropertyMetadata(15D));

        public static readonly DependencyProperty DialogButtonFontSizeProperty
            = DependencyProperty.Register(nameof(DialogButtonFontSize),
                typeof(double),
                typeof(BaseActivityDialog),
                new PropertyMetadata(SystemFonts.MessageFontSize));

        public static readonly DependencyProperty ButtonsProperty
            = DependencyProperty.Register(nameof(Buttons),
                typeof(List<Button>),
                typeof(BaseActivityDialog),
                new FrameworkPropertyMetadata(new List<Button>(),
                    OnButtonsChanged));

        #endregion

        #region dependency properties accessors

        public string Title
        {
            get => (string)this.GetValue(TitleProperty);
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

        public List<Button> Buttons
        {
            get { return (List<Button>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

        #endregion

        private static void OnButtonsChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => StyleButtons(e.NewValue as List<Button>);

        private static void StyleButtons(List<Button> buttons)
        {
            if (buttons != null)
            {
                foreach (Button button in buttons)
                {
                    button.SetValue(MarginProperty, new Thickness(5, 0, 5, 0));
                }
            }
        }
    }
}