﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Petify.Infrastructure.DataModel.Context;

namespace Petify.Infrastructure.Migrations
{
    [DbContext(typeof(PetifyContext))]
    [Migration("20211107170855_FKAddedToPet")]
    partial class FKAddedToPet
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Petify.Domain.Access.Action", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Action", "Access");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Announcements"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Reviews"
                        },
                        new
                        {
                            Id = 3,
                            Name = "ManageUsers"
                        });
                });

            modelBuilder.Entity("Petify.Domain.Access.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role", "Access");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "RegularUser"
                        });
                });

            modelBuilder.Entity("Petify.Domain.Access.RoleAction", b =>
                {
                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId", "ActionId");

                    b.HasIndex("ActionId");

                    b.ToTable("RoleAction", "Access");

                    b.HasData(
                        new
                        {
                            RoleId = 1,
                            ActionId = 3,
                            Level = "F"
                        },
                        new
                        {
                            RoleId = 2,
                            ActionId = 1,
                            Level = "F"
                        },
                        new
                        {
                            RoleId = 2,
                            ActionId = 2,
                            Level = "F"
                        });
                });

            modelBuilder.Entity("Petify.Domain.Access.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("User", "Access");
                });

            modelBuilder.Entity("Petify.Domain.Access.UserAction", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "ActionId");

                    b.HasIndex("ActionId");

                    b.ToTable("UserAction", "Access");
                });

            modelBuilder.Entity("Petify.Domain.Access.UserPermission", b =>
                {
                    b.Property<int>("ActionId")
                        .HasColumnType("int");

                    b.Property<string>("Level")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToView("VW_UserPermissions", "Access");
                });

            modelBuilder.Entity("Petify.Domain.Access.UserRole", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("UserRole", "Access");
                });

            modelBuilder.Entity("Petify.Domain.Lookups.SpeciesType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("SpeciesType", "Lookup");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Dog"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Cat"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Hamster"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Horse"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Fish"
                        },
                        new
                        {
                            Id = 6,
                            Name = "GuineaPig"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Pig"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Meerkat"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Snake"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Rabbit"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Spider"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Bird"
                        });
                });

            modelBuilder.Entity("Petify.Domain.Pets.Pet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFileStorageId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SpeciesId")
                        .HasColumnType("int");

                    b.Property<string>("UpdatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Pet", "Pet");
                });

            modelBuilder.Entity("Petify.Domain.Access.RoleAction", b =>
                {
                    b.HasOne("Petify.Domain.Access.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Petify.Domain.Access.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Petify.Domain.Access.UserAction", b =>
                {
                    b.HasOne("Petify.Domain.Access.Action", "Action")
                        .WithMany()
                        .HasForeignKey("ActionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Petify.Domain.Access.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Action");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Petify.Domain.Access.UserRole", b =>
                {
                    b.HasOne("Petify.Domain.Access.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Petify.Domain.Access.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Petify.Domain.Pets.Pet", b =>
                {
                    b.HasOne("Petify.Domain.Access.User", null)
                        .WithMany("Pets")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Petify.Domain.Access.User", b =>
                {
                    b.Navigation("Pets");
                });
#pragma warning restore 612, 618
        }
    }
}
