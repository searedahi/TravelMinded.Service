﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TravelMinded.Service.DAL;

namespace TravelMinded.Service.Migrations
{
    [DbContext(typeof(TravelMindedContext))]
    partial class TravelMindedContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.AddressInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City");

                    b.Property<string>("Country");

                    b.Property<string>("PostalCode");

                    b.Property<string>("Province");

                    b.Property<string>("Street");

                    b.HasKey("Id");

                    b.ToTable("AddressInfo");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<string>("Currency");

                    b.Property<string>("Description");

                    b.Property<bool>("IsFareHarborVendor");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Companies");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.CustomerPrototype", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("DisplayName");

                    b.Property<int?>("ExperienceId");

                    b.Property<int>("Pk");

                    b.Property<int>("Total");

                    b.Property<int>("TravelMindedCustomerTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ExperienceId");

                    b.ToTable("CustomerPrototype");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CancellationPolicy");

                    b.Property<string>("CancellationPolicySafeHtml");

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Currency");

                    b.Property<string>("Description");

                    b.Property<string>("DescriptionSafeHtml");

                    b.Property<string>("DescriptionText");

                    b.Property<int>("Duration");

                    b.Property<string>("Headline");

                    b.Property<string>("ImageCdnUrl");

                    b.Property<bool>("IsPickupEverOffered");

                    b.Property<string>("Location");

                    b.Property<string>("Name");

                    b.Property<int>("Pk");

                    b.Property<decimal>("Price");

                    b.Property<string>("ShortName");

                    b.Property<decimal>("TaxPercentage");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.ImageInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ExperienceId");

                    b.Property<string>("Gallery");

                    b.Property<string>("ImageCdnUrl");

                    b.Property<int>("Pk");

                    b.HasKey("Id");

                    b.HasIndex("ExperienceId");

                    b.ToTable("ImageInfo");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.LocationInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("AddressId");

                    b.Property<int?>("ExperienceId");

                    b.Property<string>("GooglePlaceId");

                    b.Property<decimal>("Latitude");

                    b.Property<decimal>("Longitude");

                    b.Property<string>("Note");

                    b.Property<string>("NoteSafeHtml");

                    b.Property<int>("Pk");

                    b.Property<string>("TripadvisorUrl");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("ExperienceId");

                    b.ToTable("LocationInfo");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CompanyId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<string>("ShortName");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.Company", b =>
                {
                    b.HasOne("TravelMinded.Service.DAL.DbModel.AddressInfo", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.CustomerPrototype", b =>
                {
                    b.HasOne("TravelMinded.Service.DAL.DbModel.Experience")
                        .WithMany("CustomerPrototypes")
                        .HasForeignKey("ExperienceId");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.Experience", b =>
                {
                    b.HasOne("TravelMinded.Service.DAL.DbModel.Company", "Company")
                        .WithMany("Experiences")
                        .HasForeignKey("CompanyId");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.ImageInfo", b =>
                {
                    b.HasOne("TravelMinded.Service.DAL.DbModel.Experience")
                        .WithMany("Images")
                        .HasForeignKey("ExperienceId");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.LocationInfo", b =>
                {
                    b.HasOne("TravelMinded.Service.DAL.DbModel.AddressInfo", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.HasOne("TravelMinded.Service.DAL.DbModel.Experience")
                        .WithMany("Locations")
                        .HasForeignKey("ExperienceId");
                });

            modelBuilder.Entity("TravelMinded.Service.DAL.DbModel.Product", b =>
                {
                    b.HasOne("TravelMinded.Service.DAL.DbModel.Company", "Company")
                        .WithMany("Products")
                        .HasForeignKey("CompanyId");
                });
#pragma warning restore 612, 618
        }
    }
}
