using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities;

public class Debt {
    public int Id { get; set; }
    [AllowNull]
    public Body Body { get; set; }
    [AllowNull]
    public Bank Bank { get; set; }
    public DateOnly DeadlineDate { get; set; }
    public decimal RawExpectedPayment { get; set; }
}
