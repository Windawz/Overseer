using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class ArgumentTypeMismatchException : CommandException {
    public ArgumentTypeMismatchException(string arg, ParameterDescriptor descriptor, int at) {
        Arg = arg;
        Descriptor = descriptor;
    }

    public string Arg { get; }
    public ParameterDescriptor Descriptor { get; }
    public int At { get; }
    public override string Message =>
        $"Invalid argument provided at position {At}: parameter: \"{Descriptor.Name}\", value: \"{Arg}\"";
}
