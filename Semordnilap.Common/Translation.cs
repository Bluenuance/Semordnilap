using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Semordnilap.Common
{
    public class Translation
    {

        private static readonly IDictionary<string, Func<IAminoAcid>> CodonTable = new Dictionary<string, Func<IAminoAcid>>
        {
            //STOP 	UAA, UGA, UAG 
            { "UAA", () => new PseudoEndAminoAcid() }, { "UGA", () => new PseudoEndAminoAcid() }, { "UAG", () => new PseudoEndAminoAcid() },

            //Ala, A 	GCU, GCC, GCA, GCG 
            { "GCU", () => new Alanine() }, { "GCC", () => new Alanine() }, { "GCA", () => new Alanine() }, { "GCG", () => new Alanine() },
            //Arg, R 	CGU, CGC, CGA, CGG; AGA, AGG
            { "CGU", () => new Arginine() }, { "CGC", () => new Arginine() }, { "CGA", () => new Arginine() }, { "CGG", () => new Arginine() }, { "AGA", () => new Arginine() }, { "AGG", () => new Arginine() },
            //Asn, N 	AAU, AAC 
            { "AAU", () => new Asparagine() }, { "AAC", () => new Asparagine() }, 
            //Asp, D 	GAU, GAC 
            { "GAU", () => new AsparticAcid() }, { "GAC", () => new AsparticAcid() },
            //Cys, C 	UGU, UGC 
            { "UGU", () => new Cysteine() }, { "UGC", () => new Cysteine() },
            //Gln, Q 	CAA, CAG 
            { "CAA", () => new Glutamine() }, { "CAG", () => new Glutamine() },
            //Glu, E 	GAA, GAG 
            { "GAA", () => new GlutamicAcid() }, { "GAG", () => new GlutamicAcid() },
            //Gly, G 	GGU, GGC, GGA, GGG 
            { "GGU", () => new Glycine() }, { "GGC", () => new Glycine() }, { "GGA", () => new Glycine() }, { "GGG", () => new Glycine() },
            //His, H 	CAU, CAC 
            { "CAU", () => new Histidine() }, { "CAC", () => new Histidine() },
            //Ile, I 	AUU, AUC, AUA
            { "AUU", () => new Isoleucine() }, { "AUC", () => new Isoleucine() }, { "AUA", () => new Isoleucine() },
            //Leu, L 	CUU, CUC, CUA, CUG; UUA, UUG
            { "CUU", () => new Leucine() }, { "CUC", () => new Leucine() }, { "CUA", () => new Leucine() }, { "CUG", () => new Leucine() }, { "UUA", () => new Leucine() }, { "UUG", () => new Leucine() }, 
            //Lys, K 	AAA, AAG 
            { "AAA", () => new Lysine() }, { "AAG", () => new Lysine() },
            //Met, M 	AUG 
            { "AUG", () => new Methionine() },
            //Phe, F 	UUU, UUC 
            { "UUU", () => new Phenylalanine() }, { "UUC", () => new Phenylalanine() },
            //Pro, P 	CCU, CCC, CCA, CCG 
            { "CCU", () => new Proline() }, { "CCC", () => new Proline() }, { "CCA", () => new Proline() }, { "CCG", () => new Proline() },
            //Ser, S 	UCU, UCC, UCA, UCG; AGU, AGC
            { "UCU", () => new Serine() }, { "UCC", () => new Serine() }, { "UCA", () => new Serine() }, { "UCG", () => new Serine() }, { "AGU", () => new Serine() }, { "AGC", () => new Serine() },
            //Thr, T 	ACU, ACC, ACA, ACG 
            { "ACU", () => new Threonine() }, { "ACC", () => new Threonine() }, { "ACA", () => new Threonine() }, { "ACG", () => new Threonine() },
            //Trp, W 	UGG 
            { "UGG", () => new Tryptophane() },
            //Tyr, Y 	UAU, UAC 
            { "UAU", () => new Tyrosine() }, { "UAC", () => new Tyrosine() },
            //Val, V 	GUU, GUC, GUA, GUG 
            { "GUU", () => new Valine() }, { "GUC", () => new Valine() }, { "GUA", () => new Valine() }, { "GUG", () => new Valine() },
        };

        private static IAminoAcid ToAminoAcid(INucleobase nb1, INucleobase nb2, INucleobase nb3)
        {
            string tripletCode = new string(new char[3]{ nb1.Letter, nb2.Letter, nb3.Letter });
            Func<IAminoAcid> func = CodonTable[tripletCode];
            return func();
        }

        public static Protein ToProtein(IList<INucleobase> nucleobaseChain)
        {
            Debug.Assert(nucleobaseChain.Count % 3 == 0);

            var protein = new Protein();

            IEnumerator<INucleobase> enumerator = nucleobaseChain.GetEnumerator();
            while (enumerator.MoveNext())
            {
                INucleobase nb1 = enumerator.Current;
                enumerator.MoveNext();
                INucleobase nb2 = enumerator.Current;
                enumerator.MoveNext();
                INucleobase nb3 = enumerator.Current;

                IAminoAcid aa = ToAminoAcid(nb1, nb2, nb3);
                protein.Add(aa);
            }
            

            return protein;
        }



    }
}
