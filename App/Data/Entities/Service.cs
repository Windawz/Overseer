using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities;

public class Service {
    public int Id { get; set; }
    [AllowNull]
    public string Name { get; set; }
    [AllowNull]
    public List<Tax> Taxes { get; set; }
}
