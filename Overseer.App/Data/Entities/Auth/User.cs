using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities.Auth;

public class User
{
    public int Id { get; set; }
    [AllowNull]
    public string UserName { get; set; }
    public UserKind Kind { get; set; }
    [AllowNull]
    public string Password { get; set; }
}
