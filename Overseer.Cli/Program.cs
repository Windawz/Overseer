using System.Text.Json;

using Overseer.Data;

namespace Overseer.Cli;
public class Program {
    public static void Main() {
        Console.WriteLine(Configuration.WelcomeMessage);

        bool isRunning = true;
        while (isRunning) {

        }
    }

    private static Dialogue MakeDialogue(Api api, Action onQuit) {
        var builder = new DialogueBuilder();
        builder
            .HasApi(api)
            .HasCommandNotFoundHandler((dialogue, commandName) => {
                Console.WriteLine($"Invalid command: \"{commandName}\"");
            })
            .HasQuitHandler(onQuit)
            .HasCommand("list", commandBuilder => {
                commandBuilder.HasParameter("entity", parameterBuilder => {
                    parameterBuilder.HasDescription("Name of the entity column to list");
                })
                .HasAction((dialogue, args) => {
                    object[] entities = dialogue.Api.Get(Type.GetType($"Overseer.Data.{args[0]}")!);
                    foreach (var entity in entities) {
                        Console.WriteLine(entity.ToString());
                    }
                });
            });
    }
}