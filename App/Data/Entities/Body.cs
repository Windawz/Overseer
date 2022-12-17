using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities;

public class Body {
    public int Id { get; set; }
    [AllowNull]
    public string Name { get; set; }
    [AllowNull]
    public List<Service> Services { get; set; }
}
