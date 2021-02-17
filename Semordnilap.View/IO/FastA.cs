using Semordnilap.Common;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace Semordnilap.View.IO
{
    public interface IInputSequence
    {
        //for now: only a amino acid can be in an input sequence
        IEnumerable<IAminoAcid> Parse(Stream inputStream);
    }

    public class FastA : IInputSequence
    {
        private class Sequence
        {
            private readonly Comment _comment = new Comment();
            private readonly Letters _letters = new Letters();

            internal string Comment => _comment._value;
            internal IEnumerable<char> Letters => _letters._value;

            public void Process(StreamReader reader)
            {
                bool sequenceStarted = false;

                while (!reader.EndOfStream)
                {
                    int token = reader.Peek();
                    switch (token)
                    {
                        case 10: //end of line
                            reader.ReadLine();
                            break;
                        case 32: //space
                            reader.Read();
                            break;
                        case 59 when sequenceStarted:
                        case 62 when sequenceStarted:
                            return; //sequence is done
                        case 59: //';'
                        case 62: //'<'
                            _comment.Process(reader);
                            break;
                        default:
                            _letters.Process(reader);
                            sequenceStarted = true;
                            break;
                    }
                }
            }
        }

        private class Comment
        {
            internal string _value = "";

            internal void Process(StreamReader reader)
            {
                _value += reader.ReadLine();
            }
        }

        private class Letters
        {
            internal string _value;

            internal void Process(StreamReader reader)
            {
                var str = new StringBuilder();
                //read line, there can be spaces
                int r;
                while ((r = reader.Read()) != 10 /*EOL*/)
                {
                    if (r == -1 /*EOL*/)
                    {
                        break;
                    }
                    else if (r == 32 /*space*/)
                    {
                        continue;
                    }
                    else if (r == 9 /*tab*/)
                    {
                        continue;
                    }
                    else
                    {
                        str.Append((char)r);
                    }
                }
                _value += str.ToString();
                //_value += reader.ReadLine();
            }
        }

        public IEnumerable<IAminoAcid> Parse(Stream inputStream)
        {
            var sequences = new List<Sequence>();

            var reader = new StreamReader(inputStream);
            while (!reader.EndOfStream)
            {
                var sequence = new Sequence();
                sequence.Process(reader);
                sequences.Add(sequence);
            }

            //for now only proteins (amino acids) AND only the FIRST one are assumed in the fasta file
            var proteins = new List<Protein>();
            foreach (var sequence in sequences)
            {
                var protein = new Protein();
                protein.Description = sequence.Comment;

                foreach (char letter in sequence.Letters)
                {
                    protein.Add(AminoAcids.FromLetter(letter));
                }

                proteins.Add(protein);
            }

            return proteins.First();
        }
    }
}
