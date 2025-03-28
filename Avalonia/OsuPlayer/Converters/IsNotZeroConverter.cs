using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Milki.OsuPlayer.Converters
{
    public class IsNotZeroConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is double doubleValue)
            {
                return Math.Abs(doubleValue) > 0.0000001;
            }
            
            if (value is int intValue)
            {
                return intValue != 0;
            }
            
            if (value is float floatValue)
            {
                return Math.Abs(floatValue) > 0.0000001f;
            }
            
            if (value is decimal decimalValue)
            {
                return decimalValue != 0;
            }
            
            return false;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
} 