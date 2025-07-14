using AspTest.DomainClasses.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AspTest.DataAccess.Models;

public class CountyEntityMap : IEntityTypeConfiguration<County>
{
    public void Configure(EntityTypeBuilder<County> builder)
    {
        builder.ToTable("Counties");
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Name).IsRequired().HasMaxLength(30);
        
        builder.HasIndex(c => new { c.Name, c.ProvinceId })
            .IsUnique();

        builder.HasOne(c => c.Province)
            .WithMany(p => p.Counties)
            .HasForeignKey(c => c.ProvinceId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}