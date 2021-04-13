﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ParkBee.Infrastructure;

namespace ParkBee.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    partial class ApplicationContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ParkBee.Domain.GarageAggregate.Door", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoorType")
                        .HasColumnType("int");

                    b.Property<Guid?>("GarageDetailId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("IPAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("GarageDetailId");

                    b.ToTable("Doors", "parkbee");
                });

            modelBuilder.Entity("ParkBee.Domain.GarageAggregate.Garage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CountryCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GarageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Garages", "parkbee");
                });

            modelBuilder.Entity("ParkBee.Domain.GarageAggregate.GarageDetail", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("GarageId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("GarageName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("GarageId")
                        .IsUnique();

                    b.ToTable("GarageDetails", "parkbee");
                });

            modelBuilder.Entity("ParkBee.Domain.UserAggregate.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Users", "parkbee");
                });

            modelBuilder.Entity("ParkBee.Domain.GarageAggregate.Door", b =>
                {
                    b.HasOne("ParkBee.Domain.GarageAggregate.GarageDetail", "GarageDetail")
                        .WithMany("Doors")
                        .HasForeignKey("GarageDetailId");

                    b.Navigation("GarageDetail");
                });

            modelBuilder.Entity("ParkBee.Domain.GarageAggregate.GarageDetail", b =>
                {
                    b.HasOne("ParkBee.Domain.GarageAggregate.Garage", null)
                        .WithOne("GarageDetail")
                        .HasForeignKey("ParkBee.Domain.GarageAggregate.GarageDetail", "GarageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("ParkBee.Domain.GarageAggregate.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("GarageDetailId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("City")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("City");

                            b1.Property<string>("Country")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Country");

                            b1.Property<string>("PostalCode")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("PostalCode");

                            b1.Property<string>("StreetAddress")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("StreetAddress");

                            b1.HasKey("GarageDetailId");

                            b1.ToTable("GarageDetails");

                            b1.WithOwner()
                                .HasForeignKey("GarageDetailId");
                        });

                    b.OwnsOne("ParkBee.Domain.GarageAggregate.GeoLocation", "GeoLocation", b1 =>
                        {
                            b1.Property<Guid>("GarageDetailId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("Latitude")
                                .HasColumnType("int")
                                .HasColumnName("Latitude");

                            b1.Property<int>("Longitude")
                                .HasColumnType("int")
                                .HasColumnName("Longitude");

                            b1.HasKey("GarageDetailId");

                            b1.ToTable("GarageDetails");

                            b1.WithOwner()
                                .HasForeignKey("GarageDetailId");
                        });

                    b.Navigation("Address");

                    b.Navigation("GeoLocation");
                });

            modelBuilder.Entity("ParkBee.Domain.UserAggregate.User", b =>
                {
                    b.OwnsOne("ParkBee.Domain.GarageAggregate.FullName", "FullName", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("FirstName")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("FirstName");

                            b1.Property<string>("LastName")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("LastName");

                            b1.Property<string>("MiddleName")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("MiddleName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.OwnsOne("ParkBee.Domain.UserAggregate.UserCredentials", "UserCredentials", b1 =>
                        {
                            b1.Property<Guid>("UserId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Password")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("Password");

                            b1.Property<string>("UserName")
                                .HasColumnType("nvarchar(max)")
                                .HasColumnName("UserName");

                            b1.HasKey("UserId");

                            b1.ToTable("Users");

                            b1.WithOwner()
                                .HasForeignKey("UserId");
                        });

                    b.Navigation("FullName");

                    b.Navigation("UserCredentials");
                });

            modelBuilder.Entity("ParkBee.Domain.GarageAggregate.Garage", b =>
                {
                    b.Navigation("GarageDetail");
                });

            modelBuilder.Entity("ParkBee.Domain.GarageAggregate.GarageDetail", b =>
                {
                    b.Navigation("Doors");
                });
#pragma warning restore 612, 618
        }
    }
}
