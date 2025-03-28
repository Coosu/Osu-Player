using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Milki.OsuPlayer.Converters
{
    public class BoolToPlayPauseIconConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is bool isPlaying)
            {
                // 暂停图标路径
                if (isPlaying)
                {
                    return "M512 64C264.6 64 64 264.6 64 512s200.6 448 448 448 448-200.6 448-448S759.4 64 512 64zm-64 680c-22.1 0-40-17.9-40-40V320c0-22.1 17.9-40 40-40s40 17.9 40 40v384c0 22.1-17.9 40-40 40zm176 0c-22.1 0-40-17.9-40-40V320c0-22.1 17.9-40 40-40s40 17.9 40 40v384c0 22.1-17.9 40-40 40z";
                }
                // 播放图标路径
                else
                {
                    return "M512 64C264.6 64 64 264.6 64 512s200.6 448 448 448 448-200.6 448-448S759.4 64 512 64zm144.1 454.9L437.7 677.8a8.02 8.02 0 0 1-12.7-6.5V353.7a8 8 0 0 1 12.7-6.5L656.1 506a7.9 7.9 0 0 1 0 12.9z";
                }
            }
            
            // 默认返回播放图标
            return "M512 64C264.6 64 64 264.6 64 512s200.6 448 448 448 448-200.6 448-448S759.4 64 512 64zm144.1 454.9L437.7 677.8a8.02 8.02 0 0 1-12.7-6.5V353.7a8 8 0 0 1 12.7-6.5L656.1 506a7.9 7.9 0 0 1 0 12.9z";
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}