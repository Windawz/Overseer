using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities;

public class Bank {
    public int Id { get; set; }
    [AllowNull]
    public string Name { get; set; }
}
