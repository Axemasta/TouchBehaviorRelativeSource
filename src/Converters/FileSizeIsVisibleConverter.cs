using System.Globalization;
using TouchBehaviorRelativeBinding.Models;

namespace TouchBehaviorRelativeBinding.Converters;

public class FileSizeIsVisibleConverter : IValueConverter
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

        return displayItem.FileKilobytes is not null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}