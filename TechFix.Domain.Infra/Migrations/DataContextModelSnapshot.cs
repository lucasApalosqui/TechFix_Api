﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TechFix.Domain.Infra.Contexts;

#nullable disable

namespace TechFix.Domain.Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Flunt.Notifications.Notification", b =>
                {
                    b.Property<string>("Message")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Property")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("TechFix.Domain.Entities.AddressEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Complement")
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Complement");

                    b.Property<string>("District")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("District");

                    b.Property<int>("Number")
                        .HasColumnType("INT")
                        .HasColumnName("Number");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProviderId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("State");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Street");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId")
                        .IsUnique();

                    b.ToTable("provider_address", (string)null);
                });

            modelBuilder.Entity("TechFix.Domain.Entities.ClientEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("LastName");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Slug");

                    b.Property<string>("UrlImage")
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("UrlImage");

                    b.HasKey("Id");

                    b.ToTable("Client", (string)null);
                });

            modelBuilder.Entity("TechFix.Domain.Entities.HireEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Active")
                        .HasColumnType("BIT")
                        .HasColumnName("Active");

                    b.Property<Guid>("ClientID")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ClientId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ServiceId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ServiceId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Slug");

                    b.HasKey("Id");

                    b.HasIndex("ClientID");

                    b.HasIndex("ServiceId");

                    b.ToTable("Hire", (string)null);
                });

            modelBuilder.Entity("TechFix.Domain.Entities.ProviderEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Cnpj")
                        .IsRequired()
                        .HasMaxLength(14)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Cnpj");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("PasswordHash");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Slug");

                    b.Property<string>("UrlImage")
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("UrlImage");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Cnpj" }, "IX_Provider_Cnpj")
                        .IsUnique();

                    b.ToTable("Provider", (string)null);
                });

            modelBuilder.Entity("TechFix.Domain.Entities.ServiceEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Amount")
                        .HasColumnType("FLOAT")
                        .HasColumnName("Amount");

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT")
                        .HasColumnName("Description");

                    b.Property<Guid>("ProviderId")
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("ProviderId");

                    b.Property<string>("Slug")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("NVARCHAR")
                        .HasColumnName("Slug");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR")
                        .HasColumnName("Title");

                    b.HasKey("Id");

                    b.HasIndex("ProviderId");

                    b.ToTable("Provider_Service", (string)null);
                });

            modelBuilder.Entity("TechFix.Domain.Entities.AddressEntity", b =>
                {
                    b.HasOne("TechFix.Domain.Entities.ProviderEntity", "Provider")
                        .WithOne("Address")
                        .HasForeignKey("TechFix.Domain.Entities.AddressEntity", "ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Provider_Address");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("TechFix.Domain.Entities.ClientEntity", b =>
                {
                    b.OwnsOne("TechFix.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ClientEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("EmailAdress")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Email");

                            b1.HasKey("ClientEntityId");

                            b1.ToTable("Client");

                            b1.WithOwner()
                                .HasForeignKey("ClientEntityId");
                        });

                    b.OwnsOne("TechFix.Domain.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("ClientEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Phone");

                            b1.HasKey("ClientEntityId");

                            b1.ToTable("Client");

                            b1.WithOwner()
                                .HasForeignKey("ClientEntityId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Phone");
                });

            modelBuilder.Entity("TechFix.Domain.Entities.HireEntity", b =>
                {
                    b.HasOne("TechFix.Domain.Entities.ClientEntity", "Client")
                        .WithMany("Hires")
                        .HasForeignKey("ClientID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Client_Hire");

                    b.HasOne("TechFix.Domain.Entities.ServiceEntity", "Service")
                        .WithMany("Hires")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Service_Hire");

                    b.Navigation("Client");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("TechFix.Domain.Entities.ProviderEntity", b =>
                {
                    b.OwnsOne("TechFix.Domain.ValueObjects.Email", "Email", b1 =>
                        {
                            b1.Property<Guid>("ProviderEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("EmailAdress")
                                .IsRequired()
                                .HasMaxLength(150)
                                .HasColumnType("NVARCHAR")
                                .HasColumnName("Email");

                            b1.HasKey("ProviderEntityId");

                            b1.ToTable("Provider");

                            b1.WithOwner()
                                .HasForeignKey("ProviderEntityId");
                        });

                    b.OwnsOne("TechFix.Domain.ValueObjects.Phone", "Phone", b1 =>
                        {
                            b1.Property<Guid>("ProviderEntityId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(11)
                                .HasColumnType("VARCHAR")
                                .HasColumnName("Phone");

                            b1.HasKey("ProviderEntityId");

                            b1.ToTable("Provider");

                            b1.WithOwner()
                                .HasForeignKey("ProviderEntityId");
                        });

                    b.Navigation("Email")
                        .IsRequired();

                    b.Navigation("Phone")
                        .IsRequired();
                });

            modelBuilder.Entity("TechFix.Domain.Entities.ServiceEntity", b =>
                {
                    b.HasOne("TechFix.Domain.Entities.ProviderEntity", "Provider")
                        .WithMany("Services")
                        .HasForeignKey("ProviderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Provider_Service");

                    b.Navigation("Provider");
                });

            modelBuilder.Entity("TechFix.Domain.Entities.ClientEntity", b =>
                {
                    b.Navigation("Hires");
                });

            modelBuilder.Entity("TechFix.Domain.Entities.ProviderEntity", b =>
                {
                    b.Navigation("Address");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("TechFix.Domain.Entities.ServiceEntity", b =>
                {
                    b.Navigation("Hires");
                });
#pragma warning restore 612, 618
        }
    }
}
