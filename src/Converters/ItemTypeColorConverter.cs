using System.Globalization;
using TouchBehaviorRelativeBinding.Models;

namespace TouchBehaviorRelativeBinding.Converters;

public class ItemTypeColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is null)
        {
            return null;
        }
        
        if (value is not DisplayItem displayItem)
        {
            throw new NotSupportedException($"Value must be of type {nameof(DisplayItem)}");
        }

        switch (displayItem.Type)
        {
            case ItemType.File:
            {
                return Color.FromArgb("#ffbf22");
            }

            case ItemType.Folder:
            {
                return Color.FromArgb("#9865b0");
            }

            default:
            {
                return Colors.Black;
            }
        }
    }

    public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}