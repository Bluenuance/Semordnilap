using System;
using System.Linq;

namespace Semordnilap.Common
{
    public class Transkription
    {

        private static INucleobase ToRna(INucleobase nucleobase)
        {
            if (nucleobase.Letter == Adenine.LetterCode)
                return new Adenine();

            if (nucleobase.Letter == Cytosine.LetterCode)
                return new Cytosine();

            if (nucleobase.Letter == Guanine.LetterCode)
                return new Guanine();

            if (nucleobase.Letter == Thymine.LetterCode)
                return new Uracil();

            throw Exception();
        }

        private static Exception Exception()
        {
            throw new NotImplementedException();
        }

        public static RNA ToRna(DNA dna)
        {
            var rna = new RNA();
            rna.Add(dna.Code.Select(c => ToRna(c)).ToList());
            return rna;
        }


    }


}


