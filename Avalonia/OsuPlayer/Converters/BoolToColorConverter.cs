using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media;

namespace Milki.OsuPlayer.Converters
{
    public class BoolToColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool boolValue)
            {
                return new SolidColorBrush(boolValue ? Color.Parse("#DE4958") : Color.Parse("#646C77"));
            }
            
            return new SolidColorBrush(Color.Parse("#646C77"));
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
