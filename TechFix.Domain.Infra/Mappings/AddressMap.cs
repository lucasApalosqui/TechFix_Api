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
    public class AddressMap : IEntityTypeConfiguration<AddressEntity>
    {
        public void Configure(EntityTypeBuilder<AddressEntity> builder)
        {
            builder.ToTable("provider_address");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Street)
                .HasColumnName("Street")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();


            builder.Property(x => x.District)
                .HasColumnName("District")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.State)
                .HasColumnName("State")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Number)
                .HasColumnName("Number")
                .HasColumnType("INT")
                .IsRequired();

            builder.Property(x => x.Complement)
                .HasColumnName("Complement")
                .HasColumnType("NVARCHAR");

            builder.Property(x => x.ProviderId)
                .HasColumnName("ProviderId")
                .IsRequired();

            builder.Ignore(x => x.Notifications);

        }
    }
}
