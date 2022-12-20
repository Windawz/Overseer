using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class Command {
    public Command(Action<Dialogue, string[]> action) {
        _action = action;
    }

    private readonly Action<Dialogue, string[]> _action;
    
    public ParameterDescriptor[] Parameters { get; set; } = Array.Empty<ParameterDescriptor>();

    public void Execute(Dialogue dialogue, string[] args) {
        if (!DoCountsMatch(args)) {
            throw new ArgumentCountMismatchException(Parameters.Length, args.Length);
        }
        if (!DoTypesMatch(args, out int mismatchIndex)) {
            throw new ArgumentTypeMismatchException(args[mismatchIndex], Parameters[mismatchIndex], mismatchIndex + 1);
        }
        _action(dialogue, args);
    }

    private bool DoCountsMatch(string[] args) {
        return args.Length == Parameters.Length;
    }

    private bool DoTypesMatch(string[] args, out int mismatchIndex) {
        var triples = args
            .Zip(Parameters)
            .Select((pair, index) => (arg: pair.First, parameter: pair.Second, index: index));
        foreach (var triple in triples) {
            var (arg, parameter, index) = triple;
            if (!parameter.Validator(arg)) {
                mismatchIndex = index;
                return false;
            }
        }
        mismatchIndex = default;
        return true;
    }
}
