﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace SimpleCrud.Controls.Converters
{
    public sealed class ProgressDialogCancelButtonVisibilityConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            => null;
    }
}