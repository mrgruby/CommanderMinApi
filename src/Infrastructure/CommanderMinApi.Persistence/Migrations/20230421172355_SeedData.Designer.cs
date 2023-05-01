﻿// <auto-generated />
using System;
using CommanderMinApi.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CommanderMinApi.Persistence.Migrations
{
    [DbContext(typeof(CommanderMinApiDbContext))]
    [Migration("20230421172355_SeedData")]
    partial class SeedData
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CommanderMinApi.Domain.Entities.CommandLine", b =>
                {
                    b.Property<Guid>("CommandLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HowTo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Line")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("PlatformId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommandLineId");

                    b.HasIndex("PlatformId");

                    b.ToTable("CommandLines");

                    b.HasData(
                        new
                        {
                            CommandLineId = new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                            Comment = "This is a comment",
                            HowTo = "Generate new module",
                            Line = "This is the command",
                            PlatformId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            PlatformName = "Angular CLI"
                        },
                        new
                        {
                            CommandLineId = new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                            Comment = "This is a comment",
                            HowTo = "Generate new component",
                            Line = "This is the command",
                            PlatformId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            PlatformName = "Angular CLI"
                        },
                        new
                        {
                            CommandLineId = new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                            Comment = "This is a comment",
                            HowTo = "Generate new Service",
                            Line = "This is the command",
                            PlatformId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            PlatformName = "Angular CLI"
                        },
                        new
                        {
                            CommandLineId = new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                            Comment = "This is a comment",
                            HowTo = "Add new migratation",
                            Line = "This is the command",
                            PlatformId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            PlatformName = "Entity Framework"
                        },
                        new
                        {
                            CommandLineId = new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                            Comment = "This is a comment",
                            HowTo = "Update database",
                            Line = "This is the command",
                            PlatformId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            PlatformName = "Entity Framework"
                        },
                        new
                        {
                            CommandLineId = new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                            Comment = "This is a comment",
                            HowTo = "Update packages",
                            Line = "This is the command",
                            PlatformId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            PlatformName = "Entity Framework"
                        },
                        new
                        {
                            CommandLineId = new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                            Comment = "This is a comment",
                            HowTo = "Push code",
                            Line = "This is the command",
                            PlatformId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            PlatformName = "Git commands"
                        },
                        new
                        {
                            CommandLineId = new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                            Comment = "This is a comment",
                            HowTo = "Change branch",
                            Line = "This is the command",
                            PlatformId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            PlatformName = "Git commands"
                        },
                        new
                        {
                            CommandLineId = new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                            Comment = "This is a comment",
                            HowTo = "Add new repository",
                            Line = "This is the command",
                            PlatformId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            PlatformName = "Git commands"
                        });
                });

            modelBuilder.Entity("CommanderMinApi.Domain.Entities.Platform", b =>
                {
                    b.Property<Guid>("PlatformId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PlatformDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlatformImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PlatformName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PlatformId");

                    b.ToTable("Platforms");

                    b.HasData(
                        new
                        {
                            PlatformId = new Guid("b0788d2f-8003-43c1-92a4-edc76a7c5dde"),
                            PlatformDescription = "",
                            PlatformImageUrl = "",
                            PlatformName = "Angular CLI"
                        },
                        new
                        {
                            PlatformId = new Guid("6313179f-7837-473a-a4d5-a5571b43e6a6"),
                            PlatformDescription = "",
                            PlatformImageUrl = "",
                            PlatformName = "Entity Framework"
                        },
                        new
                        {
                            PlatformId = new Guid("bf3f3002-7e53-441e-8b76-f6280be284aa"),
                            PlatformDescription = "",
                            PlatformImageUrl = "",
                            PlatformName = "Git commands"
                        });
                });

            modelBuilder.Entity("CommanderMinApi.Domain.Entities.CommandLine", b =>
                {
                    b.HasOne("CommanderMinApi.Domain.Entities.Platform", "Platform")
                        .WithMany("CommandLineList")
                        .HasForeignKey("PlatformId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Platform");
                });

            modelBuilder.Entity("CommanderMinApi.Domain.Entities.Platform", b =>
                {
                    b.Navigation("CommandLineList");
                });
#pragma warning restore 612, 618
        }
    }
}