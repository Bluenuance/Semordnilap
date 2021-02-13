using System;
using System.Collections.Generic;
using System.Linq;

namespace Semordnilap.Common
{
    //    module Purines/Pyrimidines


    public interface INucleobase
    {
        public char Letter { get; }

        public INucleobase Opposite();

        public /*override */string ToString() => new string(Letter, 1);
    }



    public class Adenine : INucleobase
    {
        public static char LetterCode => 'A';

        public char Letter => LetterCode;

        public INucleobase Opposite() => new Thymine();
        
    }

    public class Cytosine : INucleobase
    {
        public static char LetterCode => 'C';

        public char Letter => LetterCode;

        public INucleobase Opposite() => new Guanine();
    }

    public class Guanine : INucleobase
    {
        public static char LetterCode => 'G';

        public char Letter => LetterCode;

        public INucleobase Opposite() => new Cytosine();
    }

    public class Thymine : INucleobase
    {
        public static char LetterCode => 'T';

        public char Letter => LetterCode;

        public INucleobase Opposite() => new Adenine();
    }

    public class Uracil : INucleobase
    {
        public static char LetterCode => 'U';

        public char Letter => LetterCode;

        public INucleobase Opposite() => new Adenine();
    }


    public class Nucleobases
    {
        public static INucleobase FromLetter(char letter)
        {
            switch (letter)
            {
                case 'A':
                    return new Adenine();
                case 'C':
                    return new Cytosine();
                case 'G':
                    return new Guanine();
                case 'T':
                    return new Thymine();
                default:
                    throw new NotSupportedException();
            }

            //public static RGBColor FromRainbow(Rainbow colorBand) =>
            //colorBand switch
            //{
            //    Rainbow.Red => new RGBColor(0xFF, 0x00, 0x00),
            //    Rainbow.Orange => new RGBColor(0xFF, 0x7F, 0x00),
            //    Rainbow.Yellow => new RGBColor(0xFF, 0xFF, 0x00),
            //    Rainbow.Green => new RGBColor(0x00, 0xFF, 0x00),
            //    Rainbow.Blue => new RGBColor(0x00, 0x00, 0xFF),
            //    Rainbow.Indigo => new RGBColor(0x4B, 0x00, 0x82),
            //    Rainbow.Violet => new RGBColor(0x94, 0x00, 0xD3),
            //    _ => throw new ArgumentException(message: "invalid enum value", paramName: nameof(colorBand)),
            //};
        }

        public static IList<INucleobase> FromLetters(string letters)
        {
            return letters.Select(c => FromLetter(c)).ToList();
        }

    }

}


