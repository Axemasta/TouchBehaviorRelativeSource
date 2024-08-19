using System.Globalization;
using TouchBehaviorRelativeBinding.Fonts;
using TouchBehaviorRelativeBinding.Models;

namespace TouchBehaviorRelativeBinding.Converters;

public class ItemTypeImageSourceConverter : IValueConverter
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
                return new FontImageSource()
                {
                    Glyph = FontAwesomeIcons.File,
                    FontFamily = FontConstants.FontAwesomeSolid,
                    Size = 20,
                };
            }

            case ItemType.Folder:
            {
                return new FontImageSource()
                {
                    Glyph = FontAwesomeIcons.Folder,
                    FontFamily = FontConstants.FontAwesomeSolid,
                    Size = 20,
                };
            }

            default:
            {
                return new FontImageSource()
                {
                    Glyph = FontAwesomeIcons.Question,
                    FontFamily = FontConstants.FontAwesomeSolid,
                };
            }
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}