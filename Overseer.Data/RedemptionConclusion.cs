using System.Diagnostics.CodeAnalysis;

namespace Overseer.Data;

public class RedemptionConclusion {
    public int Id { get; set; }
    [AllowNull]
    public RedemptionAttempt RedemptionAttempt { get; set; }
    public decimal ActualPayment { get; set; }

    public override string ToString() =>
        $"RedemptionConclusion {{ Id = {Id}, RedemptionAttempt = {RedemptionAttempt}, ActualPayment = {ActualPayment} }}";
}
