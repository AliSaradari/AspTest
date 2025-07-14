namespace AspTest.DomainClasses.Entities;

public class Province
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public HashSet<County> Counties { get; set; } = [];
}