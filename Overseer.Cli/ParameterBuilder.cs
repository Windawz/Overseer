using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class ParameterBuilder {
    public ParameterBuilder(string name) =>
        _name = name;

    private string _name;
    private string? _description = null;
    private Func<string, bool>? _validator = null;

    public ParameterBuilder HasDescription(string description) {
        _description = description;
        return this;
    }

    public ParameterBuilder HasValidation(Func<string, bool> validator) {
        _validator = validator;
        return this;
    }

    public ParameterDescriptor Build() {
        return new ParameterDescriptor(_name) {
            Description = string.IsNullOrWhiteSpace(_description) ?
                "" : _description,
            Validator = _validator is null ?
                delegate { return true; } : _validator,
        };
    }
}
