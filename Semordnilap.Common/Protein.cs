using System.Collections.Generic;

namespace Semordnilap.Common
{

    public class Protein
    {
        private readonly IList<IAminoAcid> _aminoAcids;

        public Protein()
        {
            _aminoAcids = new List<IAminoAcid>();
        }

        public IEnumerable<IAminoAcid> AminoAcids => _aminoAcids;

        public void Add(IAminoAcid aminoAcid)
        {
            _aminoAcids.Add(aminoAcid);
        }

    }
}

