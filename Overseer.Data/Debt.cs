using System.Diagnostics.CodeAnalysis;

namespace Overseer.Data;

public class Debt {
    public int Id { get; set; }
    [AllowNull]
    public Body Body { get; set; }
    [AllowNull]
    public Bank Bank { get; set; }
    public DateOnly DeadlineDate { get; set; }
    public decimal RawExpectedPayment { get; set; }

    public override string ToString() =>
        $"Debt {{ Id = {Id}, Body = {Body}, Bank = {Bank}, DeadlineDate = {DeadlineDate}, RawExpectedPayment = {RawExpectedPayment} }}";
}
