using System.Collections.Generic;

namespace Interfaces
{
    public interface ISelect
    {
        List<string> Options { get; }
        List<string> OptionsDisplay { get; }
    }
}
