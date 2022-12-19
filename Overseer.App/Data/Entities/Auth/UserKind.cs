using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities.Auth;

public enum UserKind {
    Body = 0,
    Bank = 1,
    Taxer = 2,
    Admin = 3,
}
