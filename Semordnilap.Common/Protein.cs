using System.Collections;
using System.Collections.Generic;

namespace Semordnilap.Common
{

    public class Protein : ISequence<IAminoAcid>
    {
        private readonly IList<IAminoAcid> _aminoAcids;

        public Protein()
        {
            _aminoAcids = new List<IAminoAcid>();
        }

        public string Description { get; set; }

        public int Count => _aminoAcids.Count;

        public void Add(IAminoAcid aminoAcid)
        {
            _aminoAcids.Add(aminoAcid);
        }

        public IEnumerator<IAminoAcid> GetEnumerator()
        {
            return _aminoAcids.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _aminoAcids.GetEnumerator();
        }
    }
}

