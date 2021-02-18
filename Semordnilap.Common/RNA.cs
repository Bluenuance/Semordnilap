using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Semordnilap.Common
{
    public class RNA : ISequence<INucleobase>
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

        private IList<INucleobase> _nucleobases = new List<INucleobase>();

        public RNA()
        {
        }
       
        public string Description { get; set; }

        public int Count => _nucleobases.Count;

        public void Add(INucleobase nucleobase)
        {
            _nucleobases.Add(nucleobase);
        }

        public void Add(IEnumerable<INucleobase> nucleobases)
        {
            foreach (var nucleobase in nucleobases)
            {
                _nucleobases.Add(nucleobase);
            }
        }

        public IEnumerator<INucleobase> GetEnumerator()
        {
            return _nucleobases.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _nucleobases.GetEnumerator();
        }
    }






}

