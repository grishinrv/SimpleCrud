﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.Controls.Dialogs;

namespace SimpleCrud.Controls
{
    [TemplatePart(Name = PART_ButtonsPanel, Type = typeof(ItemsControl))]
    public class BaseActivityDialog : ContentControl
    {
        private const string PART_ButtonsPanel = "PART_ButtonsPanel";
        static BaseActivityDialog()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(BaseActivityDialog), new FrameworkPropertyMetadata(typeof(BaseActivityDialog)));
        }
        
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            _buttonsPanel = GetTemplateChild(PART_ButtonsPanel) as ItemsControl;
        }

        private ItemsControl _buttonsPanel;
        
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

        public static readonly DependencyProperty ButtonsProperty 
            = DependencyProperty.Register(nameof(Buttons), 
                typeof(List<Button>),
                typeof(BaseActivityDialog),
                new PropertyMetadata(new List<Button>()));

        public List<Button> Buttons
        {
            get { return (List<Button>)GetValue(ButtonsProperty); }
            set { SetValue(ButtonsProperty, value); }
        }

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
        #endregion
    }
}