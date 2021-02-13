using Semordnilap.Common;
using System.Windows.Controls;

namespace Semordnilap.View
{
    public class DnaValidationRule : ValidationRule
    {
        public override ValidationResult Validate(object value, System.Globalization.CultureInfo cultureInfo)
        {
            bool valid = DNA.ValidLetters((string)value);
            return new ValidationResult(valid, "Invalid letters");
        }
    }

}
