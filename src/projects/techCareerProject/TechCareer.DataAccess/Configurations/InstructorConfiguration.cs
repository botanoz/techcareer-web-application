﻿using Core.Security.Entities;
using Core.Security.SeedData;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TechCareer.DataAccess.Configurations;

public class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
{
    public void Configure(EntityTypeBuilder<Instructor> builder)
    {
        builder.ToTable("Instructors").HasKey(i => i.Id);

        builder.Property(i => i.Id).HasColumnName("Id").IsRequired();
        builder.Property(i => i.Name)
            .HasColumnName("Name")
            .HasMaxLength(10)
            .IsRequired();
        builder.Property(i => i.About)
            .HasColumnName("About")
            .HasMaxLength(500);

        builder.Property(i => i.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(i => i.UpdatedDate).HasColumnName("UpdatedDate");
        builder.Property(i => i.DeletedDate).HasColumnName("DeletedDate");

        builder.HasQueryFilter(i => !i.DeletedDate.HasValue);

        builder.HasMany(i => i.VideoEducations).WithOne(ve => ve.Instructor).HasForeignKey(ve => ve.InstructorId);
        builder.HasData(InstructorSeedData.GetSeedData());
    }
}
