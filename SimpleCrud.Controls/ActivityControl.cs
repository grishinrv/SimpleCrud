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
    public sealed class ActivityControl : ContentControl
    {
        #region Dependency properties declarations

        public static readonly DependencyProperty JobDataContextProperty =
            DependencyProperty.Register(nameof(JobDataContext), typeof(object), typeof(ActivityControl), new PropertyMetadata(null));



        #endregion

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            // Parts initialization
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
