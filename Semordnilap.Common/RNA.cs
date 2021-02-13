using System.Collections.Generic;
using System.Linq;

namespace Semordnilap.Common
{
    public class RNA
    {
        public static bool ValidLetters(string letters)
        {
            return letters.All(c => DNA.ValidLetter(c));
        }

        public static bool ValidLetter(char letter)
        {
            switch (letter)
            {
                case 'A':
                case 'C':
                case 'G':
                case 'U':
                    return true;
                default:
                    return false;
            }
        }

        public RNA(IList<INucleobase> code)
        {
            Code = code;
        }

        public IEnumerable<INucleobase> Code { get; }

    }






}

