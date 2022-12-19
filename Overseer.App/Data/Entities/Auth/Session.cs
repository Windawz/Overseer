using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities.Auth;

public class Session {
    public int Id { get; set; }
    [AllowNull]
    public Account User { get; set; }
}
