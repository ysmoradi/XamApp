using System;
using System.Globalization;
using Xamarin.Forms;

namespace XamApp.Views.Converters
{
    public class StepsCountToFontAttributesConverter : Converter<int, FontAttributes>
    {
        protected override FontAttributes Convert(int value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value % 2 == 0) /* The way we detect the number is even or odd! */
                return FontAttributes.Bold;
            return FontAttributes.Italic;
        }
    }
}
