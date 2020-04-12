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
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<short>("StateCode")
                        .HasColumnType("smallint");

                    b.Property<short>("StatusCode")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Customer");

                    b.HasData(
                        new
                        {
                            Id = new Guid("1d9cc685-2d46-455c-9d5c-e83135070926"),
                            CreatedBy = new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"),
                            CreatedOn = new DateTime(2020, 4, 12, 17, 34, 16, 802, DateTimeKind.Local).AddTicks(4136),
                            ModifiedBy = new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"),
                            ModifiedOn = new DateTime(2020, 4, 12, 17, 34, 16, 802, DateTimeKind.Local).AddTicks(3358),
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
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("ShortCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<short>("StateCode")
                        .HasColumnType("smallint");

                    b.Property<short>("StatusCode")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("Project");

                    b.HasData(
                        new
                        {
                            Id = new Guid("5ae7c4b7-3059-481f-8d6b-d4fec0bfff80"),
                            CreatedBy = new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"),
                            CreatedOn = new DateTime(2020, 4, 12, 17, 34, 16, 802, DateTimeKind.Local).AddTicks(8748),
                            CustomerId = new Guid("1d9cc685-2d46-455c-9d5c-e83135070926"),
                            Description = "Demo project",
                            ModifiedBy = new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"),
                            ModifiedOn = new DateTime(2020, 4, 12, 17, 34, 16, 802, DateTimeKind.Local).AddTicks(8001),
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
                            Id = new Guid("becae929-47ac-4134-8c0b-665d0cc7b49b"),
                            ProjectId = new Guid("5ae7c4b7-3059-481f-8d6b-d4fec0bfff80"),
                            UserId = new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f")
                        });
                });

            modelBuilder.Entity("Entities.Concrete.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = new Guid("fadb53a8-a759-4d9b-9729-994a6f55b33b"),
                            Description = "Admin role",
                            Name = "Admin"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.RolePermission", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Scheme")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("RolePermission");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b9856ea2-f8ed-4ddb-971d-45acd4afb5b2"),
                            RoleId = new Guid("fadb53a8-a759-4d9b-9729-994a6f55b33b"),
                            Scheme = "user/get"
                        });
                });

            modelBuilder.Entity("Entities.Concrete.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CreatedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid?>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<short>("StateCode")
                        .HasColumnType("smallint");

                    b.Property<short>("StatusCode")
                        .HasColumnType("smallint");

                    b.HasKey("Id");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            Id = new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"),
                            CreatedBy = new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"),
                            CreatedOn = new DateTime(2020, 4, 12, 17, 34, 16, 801, DateTimeKind.Local).AddTicks(256),
                            Email = "admin@test.com",
                            FirstName = "admin",
                            LastName = "admin",
                            ModifiedBy = new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"),
                            ModifiedOn = new DateTime(2020, 4, 12, 17, 34, 16, 800, DateTimeKind.Local).AddTicks(1937),
                            PasswordHash = "Pe/GAkoysqFrrBJ9ECjYmzO0JH6Eu6Xae3YcY5Hld39noqbz8vvhTcZp+uZ5whfJuK+PBqNpIMEACVQc7ZDqXw==",
                            PasswordSalt = "Pj8PdCe/AMmXEcpofLIwMQe487JOZKRUVj6+drP75QtaTazArhso+zE7IxN1ehtKD3ldJfJE9+Rta0knsQ9hOWBvZob6WJTIfdMW1vMy9LosGpc5VWWq1x3OFl9HiMqAz98rpS0oXd7woxZYjEFyyGyISCyLIMW+aFeqoXJq9jc=",
                            StateCode = (short)1,
                            StatusCode = (short)1
                        });
                });

            modelBuilder.Entity("Entities.Concrete.UserRole", b =>
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
                            Id = new Guid("9da59431-2834-44df-aa9f-f6d598ce4fb6"),
                            RoleId = new Guid("fadb53a8-a759-4d9b-9729-994a6f55b33b"),
                            UserId = new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f")
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
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<string>("DirectoryPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

                    b.Property<Guid>("ModifiedBy")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ModifiedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("PreviewFile")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)")
                        .HasMaxLength(1000);

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