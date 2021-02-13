using Semordnilap.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace Semordnilap.View
{

    public class NucleobaseTextCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            List<INucleobase> bases = (List<INucleobase>)value;
            return new string(bases.Select(b => b.Letter).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return Nucleobases.FromLetters((string)value).ToList();
        }
    }

}
