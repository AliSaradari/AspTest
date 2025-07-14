namespace AspTest.DomainClasses.Entities;

public class EducationDistrict
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public int CountyId { get; set; } = default!;
    public County County { get; set; } = default!;
}