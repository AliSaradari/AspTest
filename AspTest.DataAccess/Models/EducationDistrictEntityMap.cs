using AspTest.DomainClasses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspTest.DataAccess.Models;

public class EducationDistrictEntityMap : IEntityTypeConfiguration<EducationDistrict>
{
    public void Configure(EntityTypeBuilder<EducationDistrict> builder)
    {
        builder.ToTable("EducationDistricts");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
        
        builder.HasIndex(a => new { a.Name, a.CountyId })
            .IsUnique();

        builder.HasOne(a => a.County)
            .WithMany(c => c.EducationDistricts)
            .HasForeignKey(a => a.CountyId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}