using System.Diagnostics.CodeAnalysis;

namespace Overseer.Data;

public class RedemptionAttempt {
    public int Id { get; set; }
    [AllowNull]
    public Debt Debt { get; set; }
    public DateOnly AttemptDate { get; set; }
    public decimal StatedPayment { get; set; }
}
