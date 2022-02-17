using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace week11
{
    [ValueConversion(typeof(double), typeof(string))]
    public class Converter : IValueConverter
    {

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            string output;
            output = (value != null) ? string.Format($"{(double)value:F2}"): "0.00";
            return output;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            double output = 0;
            if (double.TryParse((string)value,out output))
            {
                return output;
            }
            return 0;

        }
    }
}
