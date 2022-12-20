using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class CommandBuilder {
    private List<ParameterBuilder> _parameterBuilders = new();
    private Action<Dialogue, string[]>? _action = null;

    public CommandBuilder HasParameter(string name, Action<ParameterBuilder> configurator) {
        var builder = new ParameterBuilder(name);
        configurator(builder);
        _parameterBuilders.Add(builder);
        return this;
    }

    public CommandBuilder HasAction(Action<Dialogue, string[]> action) {
        _action = action;
        return this;
    }

    public Command Build() {
        ParameterDescriptor[] parameters = _parameterBuilders
            .Select(builder => builder.Build())
            .ToArray();

        return new Command(_action is null ? delegate { } : _action) {
            Parameters = parameters,
        };
    }
}
