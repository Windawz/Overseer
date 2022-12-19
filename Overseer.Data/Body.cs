using System.Diagnostics.CodeAnalysis;

namespace Overseer.Data;

public class Body {
    public int Id { get; set; }
    [AllowNull]
    public string Name { get; set; }
    [AllowNull]
    public List<Service> Services { get; set; }

    public override string ToString() =>
        $"Body {{ Id = {Id}, Name = {Name}, Services = {{ {string.Join(", ", Services)} }} }}";
}
