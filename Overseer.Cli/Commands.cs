using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Overseer.Data;

namespace Overseer.Cli;
internal static class Commands {
    public static void ListCommand(Dialogue dialogue, string[] args) {
        if (args.Length < 1) {
            throw new ArgumentException("Expected 1 argument (entityName)");
        }
        foreach (var bank in dialogue.Api.Get<Bank>()) {
            Console.WriteLine(bank);
        }
    }
}
