namespace Overseer.Data;

public class Tax {
    public int Id { get; set; }
    public double Rate { get; set; }

    public override string ToString() =>
        $"Tax {{ Id = {Id}, Rate = {Rate} }}";
}
