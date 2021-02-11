using System;
using System.Linq;
using System.Windows.Data;
using Semordnilap;

namespace Semordnilap.View
{
    //public class NucleobaseTextCodeConverter : IValueConverter
    //{
    //    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        //value = string

            
    //    }


    //    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    //    {
    //        //TODO
    //        return "";
    //    }
    //}

    public class ReverseComplementarySequenceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            //TODO: now use the f# thingies

            //type N = Nucleobase

            //type A = Adenine
            //type C = Cytosine
            //type G = Guanine
            //type T = Thymine

            //let code: Nucleobase list = [A(); T(); G(); C(); T(); G(); A(); T(); C(); T(); T(); G(); G(); C(); C(); A(); T(); C(); A(); A(); T(); G(); ]

            //let dna = DNA(code)
            //let dnaAsLetterCode = dna.FacingStrand() |> String.Concat

            var dna = new DNA(value.ToString());
            

            //bool isenable = true;
            //if (string.IsNullOrEmpty(value.ToString()))
            //{
            //    isenable = false;
            //}
            return new string(dna.FacingStrand().Select(c => c.Sign).ToArray());
        }


        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }


}
