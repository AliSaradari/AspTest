namespace AspTest.DomainClasses.Entities;

public class County
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public int ProvinceId { get; set; }
    public Province Province { get; set; } = default!;

    public HashSet<EducationDistrict> EducationDistricts { get; set; } =
        [];
}