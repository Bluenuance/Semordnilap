using Semordnilap.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace Semordnilap.View
{
    public class AminoAcidsTextCodeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new string(((IEnumerable<IAminoAcid>)value).Select(aa => aa.Letter1).ToArray());
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {

            throw new NotImplementedException();
        }
    }

}
