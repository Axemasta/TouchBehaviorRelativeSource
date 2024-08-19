using System.Globalization;
using TouchBehaviorRelativeBinding.Extensions;
using TouchBehaviorRelativeBinding.Models;

namespace TouchBehaviorRelativeBinding.Converters;

public class FileSizeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return string.Empty;
        }
        
        if (value is not DisplayItem displayItem)
        {
            throw new NotSupportedException($"Value must be of type {nameof(DisplayItem)}");
        }

        if (displayItem.FileKilobytes is null)
        {
            return string.Empty;
        }

        return displayItem.FileKilobytes.Value.ToByteSizeString();
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}