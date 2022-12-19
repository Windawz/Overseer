using System.Diagnostics.CodeAnalysis;

namespace Overseer.Data;

public class Bank {
    public int Id { get; set; }
    [AllowNull]
    public string Name { get; set; }

    public override string ToString() =>
        $"Bank {{ Id = {Id}, Name = {Name} }}";
}
