using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Milki.OsuPlayer.Converters
{
    public class BoolToSizeConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isPlaying)
            {
                // 暂停按钮尺寸稍大
                if (isPlaying)
                {
                    return 18.0;
                }
                // 播放按钮尺寸
                else
                {
                    return 20.0;
                }
            }
            
            // 默认尺寸
            return 20.0;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}