using System.Diagnostics.CodeAnalysis;

namespace Overseer.App.Data.Entities;

public class RedemptionConclusion {
    public int Id { get; set; }
    [AllowNull]
    public RedemptionAttempt RedemptionAttempt { get; set; }
    public decimal ActualPayment { get; set; }
}
