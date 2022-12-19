using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities.Auth;

public class Session {
    public int Id { get; set; }
    [AllowNull]
    public User User { get; set; }
}
