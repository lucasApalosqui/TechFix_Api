using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Infra.Mappings
{
    public class ServiceMap : IEntityTypeConfiguration<ServiceEntity>
    {
        public void Configure(EntityTypeBuilder<ServiceEntity> builder)
        {
            builder.ToTable("Provider_Service");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Slug)
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Category)
                .HasColumnName("Category")
                .HasColumnType("VARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasColumnName("Description")
                .HasColumnType("TEXT")
                .IsRequired();

            builder.Property(x => x.Title)
                .HasColumnName("Title")
                .HasColumnType("VARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Amount)
                .HasColumnName("Amount")
                .HasColumnType("FLOAT")
                .IsRequired();

            builder.Property(x => x.ProviderId)
                .HasColumnName("ProviderId")
                .IsRequired();

            builder.HasMany(x => x.Hires)
                .WithOne(x => x.Service)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Service_Hire");

            builder.Ignore(x => x.Notifications);
               
        }
    }
}
