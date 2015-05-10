﻿using System;
using System.Globalization;
using System.Windows.Data;

namespace SDTPresentation.Converter
{
    public class DoubleNullableConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (String.IsNullOrEmpty(value.ToString()))
                return null;
            else
                return value;
        }
    }
}
