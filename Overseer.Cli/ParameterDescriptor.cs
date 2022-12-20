using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class ParameterDescriptor {
    public ParameterDescriptor(string name) {
        Name = name;
    }

    public string Name { get; set; }
    public string Description { get; set; } = "";
    public Func<string, bool> Validator { get; set; } = delegate { return true; };
}
