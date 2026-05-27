using Avalonia;
using Avalonia.Controls;
using Avalonia.Data.Converters;
using System;
using System.Globalization;

namespace Milki.OsuPlayer.Converters
{
    public class LocaleKeyToResourceConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is string key)
            {
                var resourceKey = $"ui-nav-{key.ToLower()}";
                if (Application.Current != null && Application.Current.TryFindResource(resourceKey, out var res))
                {
                    return res as string ?? value;
                }
            }
            return value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
