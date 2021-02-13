namespace Semordnilap.Common
{

    public interface IAminoAcid
    {
        public char Letter1 { get; }
        public string Letter3 { get; }
        //public Tuple<char, char, char> LetterX { get; }
    }
   
    //pseudo end
    public class PseudoEndAminoAcid : IAminoAcid
    {
        public char Letter1 => '*';
        public string Letter3 => "Ter";
    }

    //not polar, aliphatic
    public class Alanine : IAminoAcid
    {
        public char Letter1 => 'A';
        public string Letter3 => "Ala";
    }

    //not polar, aliphatic
    public class Glycine : IAminoAcid
    {
        public char Letter1 => 'G';
        public string Letter3 => "Gly";
    }

    //not polar, aliphatic
    public class Valine : IAminoAcid
    {
        public char Letter1 => 'V';
        public string Letter3 => "Val";
    }

    //not polar, aliphatic
    public class Leucine : IAminoAcid
    {
        public char Letter1 => 'L';
        public string Letter3 => "Leu";
    }

    //not polar, aliphatic
    public class Isoleucine : IAminoAcid
    {
        public char Letter1 => 'I';
        public string Letter3 => "Ile";
    }

    //not polar, aliphatic
    public class Proline : IAminoAcid
    {
        public char Letter1 => 'P';
        public string Letter3 => "Pro";
    }

    //not polar, aliphatic
    public class Methionine : IAminoAcid
    {
        public char Letter1 => 'M';
        public string Letter3 => "Met";
    }

    //not polar, aromatic rest
    public class Phenylalanine : IAminoAcid
    {
        public char Letter1 => 'F';
        public string Letter3 => "Phe";
    }

    //not polar, aromatic rest
    public class Tryptophane : IAminoAcid
    {
        public char Letter1 => 'W';
        public string Letter3 => "Trp";
    }

    //polar, aliphatic with Hydroxylgroup
    public class Serine : IAminoAcid
    {
        public char Letter1 => 'S';
        public string Letter3 => "Ser";
    }

    //polar, aliphatic with Hydroxylgroup
    public class Threonine : IAminoAcid
    {
        public char Letter1 => 'T';
        public string Letter3 => "Thr";
    }

    //polar, contains suflhydryl
    public class Cysteine : IAminoAcid
    {
        public char Letter1 => 'C';
        public string Letter3 => "Cys";
    }

    //polar, contains carboxamid
    public class Asparagine : IAminoAcid
    {
        public char Letter1 => 'N';
        public string Letter3 => "Asn";
    }

    //polar, contains carboxamid
    public class Glutamine : IAminoAcid
    {
        public char Letter1 => 'Q';
        public string Letter3 => "Gln";
    }

    //polar, aromatic rest
    public class Tyrosine : IAminoAcid
    {
        public char Letter1 => 'T';
        public string Letter3 => "Tyr";
    }

    /// very polar, charged negativ (acidic)
    public class AsparticAcid : IAminoAcid
    {
        public char Letter1 => 'D';
        public string Letter3 => "Asp";
    }

    /// very polar, charged negativ (acidic)
    public class GlutamicAcid : IAminoAcid
    {
        public char Letter1 => 'E';
        public string Letter3 => "Glu";
    }

    /// very polar, charged positive (basic/alkaline)
    public class Arginine : IAminoAcid
    {
        public char Letter1 => 'R';
        public string Letter3 => "Arg";
    }

    /// very polar, charged positive (basic/alkaline)
    public class Histidine : IAminoAcid
    {
        public char Letter1 => 'H';
        public string Letter3 => "His";
    }

    /// very polar, charged positive (basic/alkaline)
    public class Lysine : IAminoAcid
    {
        public char Letter1 => 'K';
        public string Letter3 => "Lys";
    }

}


