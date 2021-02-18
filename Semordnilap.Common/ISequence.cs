using System.Collections.Generic;

namespace Semordnilap.Common
{
    public interface ISequence<T> : IEnumerable<T>
    {
        string Description { get; }
        int Count { get; }
    }
}
