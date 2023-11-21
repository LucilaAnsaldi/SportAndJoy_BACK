﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using sport_and_joy_back_dotnet.Data;

#nullable disable

namespace sport_and_joy_back_dotnet.Migrations
{
    [DbContext(typeof(SportContext))]
    [Migration("20231121170341_v5")]
    partial class v5
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("sport_and_joy_back_dotnet.Entities.Field", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool?>("Bar")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("LockerRoom")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sport")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Fields");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bar = true,
                            Description = "Cancha de f5 para todos.",
                            Location = "Paraguay 1950",
                            LockerRoom = false,
                            Name = "futbol lindo",
                            Sport = 0,
                            UserId = 2
                        },
                        new
                        {
                            Id = 2,
                            Bar = false,
                            Description = "Cancha de voley para todos.",
                            Location = "Corrientes 1950",
                            LockerRoom = true,
                            Name = "voley lindo",
                            Sport = 1,
                            UserId = 2
                        },
                        new
                        {
                            Id = 3,
                            Bar = true,
                            Description = "Cancha de tenis para todos.",
                            Location = "Entre Rios 1950",
                            LockerRoom = true,
                            Name = "tenis lindo",
                            Sport = 2,
                            UserId = 2
                        });
                });

            modelBuilder.Entity("sport_and_joy_back_dotnet.Entities.Reservation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("date");

                    b.Property<int>("FieldId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FieldId");

                    b.HasIndex("UserId");

                    b.ToTable("Reservations");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Date = new DateTime(2023, 12, 12, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FieldId = 1,
                            UserId = 3
                        },
                        new
                        {
                            Id = 2,
                            Date = new DateTime(2023, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FieldId = 2,
                            UserId = 3
                        },
                        new
                        {
                            Id = 3,
                            Date = new DateTime(2023, 12, 31, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            FieldId = 3,
                            UserId = 3
                        });
                });

            modelBuilder.Entity("sport_and_joy_back_dotnet.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "olilu@gmail.com",
                            FirstName = "Olivia",
                            Image = "https://www.clipartkey.com/mpngs/m/152-1520367_user-profile-default-image-png-clipart-png-download.png",
                            LastName = "Luciano",
                            Password = "oliolioli",
                            Role = 0
                        },
                        new
                        {
                            Id = 2,
                            Email = "visvaik@gmail.com",
                            FirstName = "Vicky",
                            Image = "https://www.clipartkey.com/mpngs/m/152-1520367_user-profile-default-image-png-clipart-png-download.png",
                            LastName = "Svaikauskas",
                            Password = "India123",
                            Role = 1
                        },
                        new
                        {
                            Id = 3,
                            Email = "luans@gmail.com",
                            FirstName = "Luci",
                            Image = "https://www.clipartkey.com/mpngs/m/152-1520367_user-profile-default-image-png-clipart-png-download.png",
                            LastName = "Ansaldi",
                            Password = "lululu",
                            Role = 2
                        });
                });

            modelBuilder.Entity("sport_and_joy_back_dotnet.Entities.Field", b =>
                {
                    b.HasOne("sport_and_joy_back_dotnet.Entities.User", "User")
                        .WithMany("Fields")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("sport_and_joy_back_dotnet.Entities.Reservation", b =>
                {
                    b.HasOne("sport_and_joy_back_dotnet.Entities.Field", "Field")
                        .WithMany("Reservations")
                        .HasForeignKey("FieldId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("sport_and_joy_back_dotnet.Entities.User", "User")
                        .WithMany("Reservations")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Field");

                    b.Navigation("User");
                });

            modelBuilder.Entity("sport_and_joy_back_dotnet.Entities.Field", b =>
                {
                    b.Navigation("Reservations");
                });

            modelBuilder.Entity("sport_and_joy_back_dotnet.Entities.User", b =>
                {
                    b.Navigation("Fields");

                    b.Navigation("Reservations");
                });
#pragma warning restore 612, 618
        }
    }
}
