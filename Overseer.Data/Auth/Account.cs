using System.Diagnostics.CodeAnalysis;

namespace Overseer.Data.Auth;

public class Account
{
    public int Id { get; set; }
    [AllowNull]
    public string UserName { get; set; }
    public AccountKind Kind { get; set; }
    [AllowNull]
    public string Password { get; set; }
}
