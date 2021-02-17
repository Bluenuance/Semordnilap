using Semordnilap.View.IO;
using System;
using System.IO;

namespace Semordnilap.View
{
    public class ImportModel
    {
        public ImportModel()
        {
            //TODO: add demo to resource Files, and get path from there
            FilePath = @"C:\bla.fasta";
            InputSequence = new FastA();
        }

        public string FilePath { get; set; }

        public IInputSequence InputSequence { get; }

    }
}
