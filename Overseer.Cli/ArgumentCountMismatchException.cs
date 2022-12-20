using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class ArgumentCountMismatchException : CommandException {
    public ArgumentCountMismatchException(int expected, int got) {
        Expected = expected;
        Got = got;
    }

    public int Expected { get; }
    public int Got { get; }
    public override string Message =>
        $"Not enough or too many arguments: expected {Expected}, got {Got}";
}
