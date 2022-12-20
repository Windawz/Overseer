using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class DialogueBuilder {
    private Api? _api = null;
    private Dictionary<string, CommandBuilder> _commandBuilders = new();
    private Action<Dialogue, CommandException>? _onCommandException = null;
    private Action<Dialogue, string>? _onCommandNotFound = null;
    private Action? _onQuit = null;

    public DialogueBuilder HasApi(Api api) {
        _api = api;
        return this;
    }

    public DialogueBuilder HasCommand(string name, Action<CommandBuilder> configurator) {
        var builder = new CommandBuilder();
        configurator(builder);
        _commandBuilders.Add(name, builder);
        return this;
    }

    public DialogueBuilder HasCommandNotFoundHandler(Action<Dialogue, string> onCommandNotFound) {
        _onCommandNotFound = onCommandNotFound;
        return this;
    }

    public DialogueBuilder HasQuitHandler(Action onQuit) {
        _onQuit = onQuit;
        return this;
    }

    public Dialogue Build() {
        if (_api is null) {
            throw new InvalidOperationException("Api missing from dialogue");
        }
        if (_onCommandException is null) {
            throw new InvalidOperationException("Command exception handler missing from dialogue");
        }
        if (_onQuit is null) {
            throw new InvalidOperationException("Quit handler missing from dialogue");
        }
        
        var commands = _commandBuilders
            .Select(kv => (kv.Key, kv.Value.Build()))
            .ToDictionary(pair => pair.Key, pair => pair.Item2);

        return new Dialogue(_api, commands, _onCommandException, _onQuit) {
            OnCommandNotFound = _onCommandNotFound ?? delegate { },
        };
    }
}
