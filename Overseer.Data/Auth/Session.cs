using System.Diagnostics.CodeAnalysis;

namespace Overseer.Data.Auth;

public class Session {
    public int Id { get; set; }
    [AllowNull]
    public Account User { get; set; }
}
