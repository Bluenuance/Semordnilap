using Semordnilap.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Data;

namespace Semordnilap.View
{
    public class ReverseComplementarySequenceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var dna = new DNA((List<INucleobase>)value);
            return new string(dna.FacingStrand().Select(c => c.Letter).ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
