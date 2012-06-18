using System;
using System.Threading;
using System.Windows.Data;

namespace SilverlightExampleApp.Converters
{
    /*
        * Use this converter for formatting dates in XAML databinding
        * Example:
        *  Text="{Binding Path=PublishDate, Converter={StaticResource DateTimeFormatter}, ConverterParameter=MMM yy}" />
        * 
        * */
    public class DateTimeConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            DateTime? bindingDate = value as DateTime?;

            if (culture == null)
            {
                culture = Thread.CurrentThread.CurrentUICulture;
            }

            if (bindingDate != null)
            {
                string dateTimeFormat = parameter as string;
                return bindingDate.Value.ToString(dateTimeFormat, culture);
            }

            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}