using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Overseer.Backend;

public class DateOnlyComparer : ValueComparer<DateOnly> {
    public DateOnlyComparer() : base(
        (left, right) => left == right,
        dateOnly => dateOnly.GetHashCode()) { }
}
