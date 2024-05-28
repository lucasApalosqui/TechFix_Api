
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TechFix.Domain.Entities;

namespace TechFix.Domain.Infra.Mappings
{
    public class ProviderMap : IEntityTypeConfiguration<ProviderEntity>
    {
        public void Configure(EntityTypeBuilder<ProviderEntity> builder)
        {
            builder.ToTable("Provider");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .HasColumnName("Name")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Slug)
                .HasColumnName("Slug")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Email)
                .HasColumnName("Email")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Phone)
                .HasColumnName("Phone")
                .HasColumnType("VARCHAR")
                .HasMaxLength(11)
                .IsRequired();

            builder.Property(x => x.UrlImage)
                .HasColumnName("UrlImage")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.PasswordHash)
                .HasColumnName("PasswordHash")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(250)
                .IsRequired();

            builder.Property(x => x.Cnpj)
                .HasColumnName("Cnpj")
                .HasColumnType("VARCHAR")
                .HasMaxLength(14)
                .IsRequired();

            builder.HasOne(x => x.Address)
                .WithOne(x => x.Provider)
                .HasForeignKey<AddressEntity>(x => x.ProviderId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Provider_Address");

            builder.HasMany(x => x.Services)
                .WithOne(x => x.Provider)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Provider_Service");


            builder.HasIndex(x => x.Email, "IX_Provider_Email")
                .IsUnique();

            builder.HasIndex(x => x.Cnpj, "IX_Provider_Cnpj")
                .IsUnique();

                

        }
    }
}
