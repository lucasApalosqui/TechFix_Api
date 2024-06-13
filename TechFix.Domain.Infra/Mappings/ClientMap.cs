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
    public class ClientMap : IEntityTypeConfiguration<ClientEntity>
    {
        public void Configure(EntityTypeBuilder<ClientEntity> builder)
        {
            builder.ToTable("Client");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Slug)
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.LastName)
                .HasColumnName("LastName")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            builder.OwnsOne(x => x.Email, email => 
            {
                email.Property(x => x.EmailAdress)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150)
                .IsRequired();

                email.Ignore(x => x.Notifications);
            });


            builder.OwnsOne(x => x.Phone, phone => 
            {
                phone.Property(x => x.PhoneNumber)
                .HasColumnName("Phone")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(11);

                phone.Ignore(x => x.Notifications);
            });

            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.UrlImage)
                .HasColumnName("UrlImage")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250);

            builder.HasMany(x => x.Hires)
                .WithOne(x => x.Client)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Client_Hire");

            builder.Ignore(x => x.Notifications);
        }
    }
}
