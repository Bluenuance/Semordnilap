using System;
using System.Diagnostics;

namespace Semordnilap.Common
{

    public interface IAminoAcid
    {
        public char Letter1 { get; }
        public string Letter3 { get; }
        //public Tuple<char, char, char> LetterX { get; }
    }

    public class AminoAcids
    {
        public static IAminoAcid FromLetter(char letter)
        {
            switch (letter)
            {
                case PseudoEndAminoAcid.LetterCode: return new PseudoEndAminoAcid();
                case Alanine.LetterCode: return new Alanine();
                case Glycine.LetterCode: return new Glycine();
                case Valine.LetterCode: return new Valine();
                case Leucine.LetterCode: return new Leucine();
                case Isoleucine.LetterCode: return new Isoleucine();
                case Proline.LetterCode: return new Proline();
                case Methionine.LetterCode: return new Methionine();
                case Phenylalanine.LetterCode: return new Phenylalanine();
                case Tryptophane.LetterCode: return new Tryptophane();
                case Serine.LetterCode: return new Serine();
                case Threonine.LetterCode: return new Threonine();
                case Cysteine.LetterCode: return new Cysteine();
                case Asparagine.LetterCode: return new Asparagine();
                case Glutamine.LetterCode: return new Glutamine();
                case Tyrosine.LetterCode: return new Tyrosine();
                case AsparticAcid.LetterCode: return new AsparticAcid();
                case GlutamicAcid.LetterCode: return new GlutamicAcid();
                case Arginine.LetterCode: return new Arginine();
                case Histidine.LetterCode: return new Histidine();
                case Lysine.LetterCode: return new Lysine();
                default:
                    throw new NotSupportedException($"unknown letter: {letter}");
            }
        }
    }

    //pseudo end
    public class PseudoEndAminoAcid : IAminoAcid
    {
        public const char LetterCode = '*';

        public char Letter1 => LetterCode;
        public string Letter3 => "Ter";
    }

    //not polar, aliphatic
    public class Alanine : IAminoAcid
    {
        public const char LetterCode = 'A';

        public char Letter1 => LetterCode;
        public string Letter3 => "Ala";
    }

    //not polar, aliphatic
    public class Glycine : IAminoAcid
    {
        public const char LetterCode = 'G';

        public char Letter1 => LetterCode;
        public string Letter3 => "Gly";
    }

    //not polar, aliphatic
    public class Valine : IAminoAcid
    {
        public const char LetterCode = 'V';

        public char Letter1 => LetterCode;
        public string Letter3 => "Val";
    }

    //not polar, aliphatic
    public class Leucine : IAminoAcid
    {
        public const char LetterCode = 'L';

        public char Letter1 => LetterCode;
        public string Letter3 => "Leu";
    }

    //not polar, aliphatic
    public class Isoleucine : IAminoAcid
    {
        public const char LetterCode = 'I';

        public char Letter1 => LetterCode;
        public string Letter3 => "Ile";
    }

    //not polar, aliphatic
    public class Proline : IAminoAcid
    {
        public const char LetterCode = 'P';

        public char Letter1 => LetterCode;
        public string Letter3 => "Pro";
    }

    //not polar, aliphatic
    public class Methionine : IAminoAcid
    {
        public const char LetterCode = 'M';

        public char Letter1 => LetterCode;
        public string Letter3 => "Met";
    }

    //not polar, aromatic rest
    public class Phenylalanine : IAminoAcid
    {
        public const char LetterCode = 'F';

        public char Letter1 => LetterCode;
        public string Letter3 => "Phe";
    }

    //not polar, aromatic rest
    public class Tryptophane : IAminoAcid
    {
        public const char LetterCode = 'W';

        public char Letter1 => LetterCode;
        public string Letter3 => "Trp";
    }

    //polar, aliphatic with Hydroxylgroup
    public class Serine : IAminoAcid
    {
        public const char LetterCode = 'S';

        public char Letter1 => LetterCode;
        public string Letter3 => "Ser";
    }

    //polar, aliphatic with Hydroxylgroup
    public class Threonine : IAminoAcid
    {
        public const char LetterCode = 'T';

        public char Letter1 => LetterCode;
        public string Letter3 => "Thr";
    }

    //polar, contains suflhydryl
    public class Cysteine : IAminoAcid
    {
        public const char LetterCode = 'C';

        public char Letter1 => LetterCode;
        public string Letter3 => "Cys";
    }

    //polar, contains carboxamid
    public class Asparagine : IAminoAcid
    {
        public const char LetterCode = 'N';

        public char Letter1 => LetterCode;
        public string Letter3 => "Asn";
    }

    //polar, contains carboxamid
    public class Glutamine : IAminoAcid
    {
        public const char LetterCode = 'Q';

        public char Letter1 => LetterCode;
        public string Letter3 => "Gln";
    }

    //polar, aromatic rest
    public class Tyrosine : IAminoAcid
    {
        public const char LetterCode = 'Y';

        public char Letter1 => LetterCode;
        public string Letter3 => "Tyr";
    }

    /// very polar, charged negativ (acidic)
    public class AsparticAcid : IAminoAcid
    {
        public const char LetterCode = 'D';

        public char Letter1 => LetterCode;
        public string Letter3 => "Asp";
    }

    /// very polar, charged negativ (acidic)
    public class GlutamicAcid : IAminoAcid
    {
        public const char LetterCode = 'E';

        public char Letter1 => LetterCode;
        public string Letter3 => "Glu";
    }

    /// very polar, charged positive (basic/alkaline)
    public class Arginine : IAminoAcid
    {
        public const char LetterCode = 'R';

        public char Letter1 => LetterCode;
        public string Letter3 => "Arg";
    }

    /// very polar, charged positive (basic/alkaline)
    public class Histidine : IAminoAcid
    {
        public const char LetterCode = 'H';

        public char Letter1 => LetterCode;
        public string Letter3 => "His";
    }

    /// very polar, charged positive (basic/alkaline)
    public class Lysine : IAminoAcid
    {
        public const char LetterCode = 'K';

        public char Letter1 => LetterCode;
        public string Letter3 => "Lys";
    }

}


