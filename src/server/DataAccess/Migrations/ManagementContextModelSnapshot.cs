﻿// <auto-generated />
using System;
using DataAccess.Concrete.EntityFramework.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DataAccess.Migrations
{
    [DbContext(typeof(ManagementContext))]
    partial class ManagementContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Core.Entities.Concrete.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("59343ec3-965d-43e6-b60e-cc6fcd2e9160"),
                            Description = "Admin role",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Scheme")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RolePermission");

                    b.HasData(
                        new
                        {
                            Id = new Guid("0622eb96-98e3-43cd-8232-ec4fb4f88936"),
                            RoleId = new Guid("59343ec3-965d-43e6-b60e-cc6fcd2e9160"),
                            Scheme = "user/get"
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordSalt")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefreshToken")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RefreshTokenExpiryDate")
                        .HasColumnType("datetime2");

                    b.Property<short>("StateCode")
                        .HasColumnType("smallint");

                    b.Property<short>("StatusCode")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"),
                            CreatedBy = new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"),
                            CreatedOn = new DateTime(2020, 6, 7, 22, 41, 10, 68, DateTimeKind.Local).AddTicks(5066),
                            Email = "admin@test.com",
                            FirstName = "admin",
                            LastName = "admin",
                            ModifiedBy = new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"),
                            ModifiedOn = new DateTime(2020, 6, 7, 22, 41, 10, 67, DateTimeKind.Local).AddTicks(8311),
                            PasswordHash = "Pe/GAkoysqFrrBJ9ECjYmzO0JH6Eu6Xae3YcY5Hld39noqbz8vvhTcZp+uZ5whfJuK+PBqNpIMEACVQc7ZDqXw==",
                            PasswordSalt = "Pj8PdCe/AMmXEcpofLIwMQe487JOZKRUVj6+drP75QtaTazArhso+zE7IxN1ehtKD3ldJfJE9+Rta0knsQ9hOWBvZob6WJTIfdMW1vMy9LosGpc5VWWq1x3OFl9HiMqAz98rpS0oXd7woxZYjEFyyGyISCyLIMW+aFeqoXJq9jc=",
                            StateCode = (short)1,
                            StatusCode = (short)1
                        });
                });

            modelBuilder.Entity("Core.Entities.Concrete.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("UserRole");

                    b.HasData(
                        new
                        {
                            Id = new Guid("f6b40ffd-c6de-444a-857f-9d942070af3c"),
                            RoleId = new Guid("59343ec3-965d-43e6-b60e-cc6fcd2e9160"),
                            UserId = new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819")
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Customer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("StateCode")
                        .HasColumnType("smallint");

                    b.Property<short>("StatusCode")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = new Guid("093db73c-11d7-4860-91d8-977b5d719f8d"),
                            CreatedBy = new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"),
                            CreatedOn = new DateTime(2020, 6, 7, 22, 41, 10, 69, DateTimeKind.Local).AddTicks(5008),
                            ModifiedBy = new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"),
                            ModifiedOn = new DateTime(2020, 6, 7, 22, 41, 10, 69, DateTimeKind.Local).AddTicks(4584),
                            Name = "Demo customer",
                            StateCode = (short)1,
                            StatusCode = (short)1
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<short>("StateCode")
                        .HasColumnType("smallint");

                    b.Property<short>("StatusCode")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fe2a33d6-00f4-4676-aa77-a159f360ff1e"),
                            CreatedBy = new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"),
                            CreatedOn = new DateTime(2020, 6, 7, 22, 41, 10, 69, DateTimeKind.Local).AddTicks(7395),
                            CustomerId = new Guid("093db73c-11d7-4860-91d8-977b5d719f8d"),
                            Description = "Demo project",
                            ModifiedBy = new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"),
                            ModifiedOn = new DateTime(2020, 6, 7, 22, 41, 10, 69, DateTimeKind.Local).AddTicks(7005),
                            Name = "Demo project",
                            ShortCode = "Demo-Project",
                            StateCode = (short)1,
                            StatusCode = (short)1
                        });
                });

            modelBuilder.Entity("Entities.Concrete.ProjectUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("ProjectUser");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6c2bf836-c4ef-497a-b7f5-dc8b0487dd74"),
                            ProjectId = new Guid("fe2a33d6-00f4-4676-aa77-a159f360ff1e"),
                            UserId = new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819")
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Version", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CustomerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DirectoryPath")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PreviewFile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<short>("StateCode")
                        .HasColumnType("smallint");

                    b.Property<short>("StatusCode")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Version");
                });
#pragma warning restore 612, 618
        }
    }
}
