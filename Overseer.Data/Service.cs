using System.Diagnostics.CodeAnalysis;

namespace Overseer.Data;

public class Service {
    public int Id { get; set; }
    [AllowNull]
    public ServiceKind Kind { get; set; }
    [AllowNull]
    public Body Body { get; set; }
}
