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
    public class HireMap : IEntityTypeConfiguration<HireEntity>
    {
        public void Configure(EntityTypeBuilder<HireEntity> builder)
        {
            builder.ToTable("Hire");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Slug)
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Active)
                .HasColumnName("Active")
                .HasColumnType("BIT")
                .IsRequired();

            builder.Property(x => x.ServiceId)
                .HasColumnName("ServiceId")
                .IsRequired();

            builder.Property(x => x.ClientID)
                .HasColumnName("ClientId")
                .IsRequired();
        }
    }
}
