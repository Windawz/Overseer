using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities.Auth;

public class OverseerSession {
    public int Id { get; set; }
    [AllowNull]
    public OverseerUser User { get; set; }
}
