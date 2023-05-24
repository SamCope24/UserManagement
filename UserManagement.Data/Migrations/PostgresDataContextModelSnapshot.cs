﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using UserManagement.Data;

#nullable disable

namespace UserManagement.Data.Migrations
{
    [DbContext(typeof(PostgresDataContext))]
    partial class PostgresDataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("UserManagement.Data.Entities.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasColumnName("id");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("date_of_birth");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Forename")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("forename");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean")
                        .HasColumnName("is_active");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("surname");

                    b.HasKey("Id")
                        .HasName("pk_users");

                    b.ToTable("users", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateOfBirth = new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "luke@jointhealliance.com",
                            Forename = "Luke",
                            IsActive = true,
                            Surname = "Skywalker"
                        },
                        new
                        {
                            Id = 2L,
                            DateOfBirth = new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "leia@jointhealliance.com",
                            Forename = "Leia",
                            IsActive = true,
                            Surname = "Organa"
                        },
                        new
                        {
                            Id = 3L,
                            DateOfBirth = new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "han@jointhealliance.com",
                            Forename = "Han",
                            IsActive = false,
                            Surname = "Solo"
                        },
                        new
                        {
                            Id = 4L,
                            DateOfBirth = new DateTime(1977, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "vader@thedeathstar.org",
                            Forename = "Darth",
                            IsActive = true,
                            Surname = "Vader"
                        },
                        new
                        {
                            Id = 5L,
                            DateOfBirth = new DateTime(896, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "yoda@jointhealliance.com",
                            Forename = "Yoda",
                            IsActive = true,
                            Surname = ""
                        },
                        new
                        {
                            Id = 6L,
                            DateOfBirth = new DateTime(57, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "obiwan@jointhealliance.com",
                            Forename = "Obi-Wan",
                            IsActive = true,
                            Surname = "Kenobi"
                        },
                        new
                        {
                            Id = 7L,
                            DateOfBirth = new DateTime(41, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "anakin@thedeathstar.org",
                            Forename = "Anakin",
                            IsActive = false,
                            Surname = "Skywalker"
                        },
                        new
                        {
                            Id = 8L,
                            DateOfBirth = new DateTime(46, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "padme@jointhealliance.com",
                            Forename = "Padmé",
                            IsActive = false,
                            Surname = "Amidala"
                        },
                        new
                        {
                            Id = 9L,
                            DateOfBirth = new DateTime(200, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "chewie@jointhealliance.com",
                            Forename = "Chewbacca",
                            IsActive = false,
                            Surname = ""
                        },
                        new
                        {
                            Id = 10L,
                            DateOfBirth = new DateTime(72, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "mace@jointhealliance.com",
                            Forename = "Mace",
                            IsActive = true,
                            Surname = "Windu"
                        },
                        new
                        {
                            Id = 11L,
                            DateOfBirth = new DateTime(15, 5, 25, 0, 0, 0, 0, DateTimeKind.Utc),
                            Email = "rey@jointhealliance.com",
                            Forename = "Rey",
                            IsActive = true,
                            Surname = ""
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
