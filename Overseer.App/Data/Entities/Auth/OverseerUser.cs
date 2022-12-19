using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities.Auth;

public class OverseerUser
{
    public int Id { get; set; }
    [AllowNull]
    public string UserName { get; set; }
    public OverseerUserKind Kind { get; set; }
    [AllowNull]
    public string Password { get; set; }
}
