using NUnit.Framework;
using Semordnilap.Common.IO;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Semordnilap.Common.Tests.IO
{
    public class FastATest
    {
        [Test]
        public void OneSequenceTest()
        {
            var fasta = new FastA();

            IEnumerable<ISequence<IAminoAcid>> sequences = fasta.Parse(ToStream(IOResources.OneSequence));
            Assert.AreEqual(1, sequences.Count());

            ISequence<IAminoAcid> sequence = sequences.Single();
            Assert.AreEqual(60, sequence.Description.Length);
            Assert.AreEqual(150, sequence.Count);
        }

        [Test]
        public void OneSequenceOldCommentTest()
        {
            var fasta = new FastA();

            IEnumerable<ISequence<IAminoAcid>> sequences = fasta.Parse(ToStream(IOResources.OneSequenceOldComment));
            Assert.AreEqual(1, sequences.Count());

            ISequence<IAminoAcid> sequence = sequences.Single();
            Assert.AreEqual(60, sequence.Description.Length);
            Assert.AreEqual(150, sequence.Count);
        }

        [Test]
        public void OneSequenceSpacedTest()
        {
            var fasta = new FastA();

            IEnumerable<ISequence<IAminoAcid>> sequences = fasta.Parse(ToStream(IOResources.OneSequenceSpaced));
            Assert.AreEqual(1, sequences.Count());

            ISequence<IAminoAcid> sequence = sequences.Single();
            Assert.AreEqual(60, sequence.Description.Length);
            Assert.AreEqual(150, sequence.Count);
        }

        [Test]
        public void MultipleSequencesTest()
        {
            var fasta = new FastA();

            IEnumerable<ISequence<IAminoAcid>> sequences = fasta.Parse(ToStream(IOResources.MultipleSequences));
            Assert.AreEqual(3, sequences.Count());

            ISequence<IAminoAcid> sequence1 = sequences.Skip(0).First();
            Assert.AreEqual(36, sequence1.Description.Length);
            Assert.AreEqual(230, sequence1.Count);
            ISequence<IAminoAcid> sequence2 = sequences.Skip(1).First();
            Assert.AreEqual(60, sequence2.Description.Length);
            Assert.AreEqual(150, sequence2.Count);
            ISequence<IAminoAcid> sequence3 = sequences.Skip(2).First();
            Assert.AreEqual(63, sequence3.Description.Length);
            Assert.AreEqual(283, sequence3.Count);
        }

        private Stream ToStream(string str)
        {
            MemoryStream stream = new MemoryStream();
            StreamWriter writer = new StreamWriter(stream);
            writer.Write(str);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }
    }
}