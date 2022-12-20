using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Overseer.Cli;
internal class Dialogue {
    public Dialogue(Api api, IReadOnlyDictionary<string, Command> commands, Action<Dialogue, CommandException> onCommandException, Action onQuit) {
        Api = api;
        Commands = commands;
        OnCommandException = onCommandException;
        OnQuit = onQuit;
    }

    public Api Api { get; }
    public IReadOnlyDictionary<string, Command> Commands { get; }
    public Action<Dialogue, string> OnCommandNotFound { get; set; } = delegate { };
    public Action<Dialogue, CommandException> OnCommandException { get; set; }
    public Action OnQuit { get; set; }

    public void Execute(string input) {
        (string commandName, string[] args) = ParseInput(input);
        if (Commands.TryGetValue(commandName, out var command)) {
            command.Execute(this, args);
        } else {
            OnCommandNotFound(this, commandName);
        }
    }

    private static (string, string[]) ParseInput(string input) {
        string[] tokens = input.Split(' ',
            StringSplitOptions.RemoveEmptyEntries
            | StringSplitOptions.TrimEntries);

        string commandName = tokens.Length == 0 ? ""
            : string.IsNullOrWhiteSpace(tokens[0]) ? ""
            : tokens[0];

        string[] args = tokens.Length == 1 ? Array.Empty<string>()
            : tokens[1..];

        return (commandName, args);
    }

    private void ExecuteCommand(Command command, string[] args) {
        try {
            command.Execute(this, args);
        } catch (CommandException e) {
            OnCommandException(this, e);
        }
    }
}
