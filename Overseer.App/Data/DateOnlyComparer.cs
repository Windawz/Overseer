using System.ComponentModel.DataAnnotations.Schema;

using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Overseer.App.Data;

public class DateOnlyComparer : ValueComparer<DateOnly> {
    public DateOnlyComparer() : base(
        (left, right) => left == right,
        dateOnly => dateOnly.GetHashCode()) { }
}
