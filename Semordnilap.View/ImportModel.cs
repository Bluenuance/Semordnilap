using Semordnilap.Common.IO;

namespace Semordnilap.View
{
    public class ImportModel
    {
        public ImportModel()
        {
            //TODO: add demo to resource Files, and get path from there
            FilePath = @"D:\Semordnilap\resources\proteins\uniprot-name dutpase+AND+reviewed yes.fasta";
            InputSequence = new FastA();
        }

        public string FilePath { get; set; }

        public IInputSequence InputSequence { get; }

    }
}
