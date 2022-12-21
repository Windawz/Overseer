using System.Text.Json;

using Overseer.Data;

namespace Overseer.Cli;
public class Program {
    public static void Main() {
        Console.WriteLine(Configuration.WelcomeMessage);

        var api = new Api();
        bool isRunning = true;
        
        var dialogue = MakeDialogue(api, () => {
            isRunning = false;
        });
        
        while (isRunning) {
            string input = Console.ReadLine()!;
            dialogue.Execute(input);
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
            })
            .HasCommand("add", commandBuilder => {
                commandBuilder.HasParameter("entity", parameterBuilder => {
                    parameterBuilder.HasDescription("Name of the entity column to add a new instance to");
                })
                .HasParameter("entityArgs", parameterBuilder => {
                    parameterBuilder.HasDescription("Arguments for the newly created entity instance")
                        .HasValidation(arg => {
                            return arg.StartsWith('(') && arg.EndsWith(')');
                        });
                })
                .HasAction((dialogue, args) => {
                    Type entityType = Type.GetType(args[0])!;

                    var memberTypes = entityType.GetMembers()
                        .Select(memberInfo => memberInfo.MemberType);
                    Activator.CreateInstance()

                    string entityArgsStr = args[1][1..^1];
                    string[] entityArgs = entityArgsStr.Split(',',
                        StringSplitOptions.RemoveEmptyEntries
                        | StringSplitOptions.TrimEntries);



                    dialogue.Api.Post();
                });
            });
    }
}