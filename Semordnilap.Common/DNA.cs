using System.Collections.Generic;
using System.Linq;


namespace Semordnilap.Common
{
    ///TODO: (re)move
    //type _NA = 

    //    static member IsDnaPart(nucleobase: Nucleobase) = 
    //        match nucleobase with
    //        | _ -> true

    //    static member IsDna(code: seq<Nucleobase>): bool = code |> Seq.forall (fun x -> _NA.IsDnaPart(x))
    public class DNA
    {

        public static bool ValidLetters(string letters)
        {
            return letters.All(c => ValidLetter(c));
        }

        public static bool ValidLetter(char letter)
        {
            switch (letter)
            {
                case 'A':
                case 'C':
                case 'G':
                case 'T':
                    return true;
                default:
                    return false;
            }
        }

        public DNA(IEnumerable<INucleobase> code)
        {
            Code = code;
        }

        public IEnumerable<INucleobase> Code { get; }

        private IList<INucleobase> Reverse(IEnumerable<INucleobase> code)
        {
            return code.Reverse().ToList();
        }

        private IList<INucleobase> Complementary(IEnumerable<INucleobase> code)
        {
            return code.Select(c => c.Opposite()).ToList();
        }

        public IList<INucleobase> FacingStrand()
        {
            return Complementary(Reverse(Code.ToList()));
        }

    }

}

