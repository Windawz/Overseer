using System.Text.Json;

using Overseer.Data;

namespace Overseer.Cli;
class Program {
    static void Main() {
        var api = new Api();
        var banks = api.Get<Bank>();
        foreach (var bank in banks) {
            Console.WriteLine($"Bank({bank.Id}, {bank.Name})");
        }
    }
}