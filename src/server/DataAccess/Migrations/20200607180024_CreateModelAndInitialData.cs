using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class CreateModelAndInitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    StatusCode = table.Column<short>(nullable: false),
                    StateCode = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Project",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ShortCode = table.Column<string>(nullable: true),
                    CustomerId = table.Column<Guid>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    StatusCode = table.Column<short>(nullable: false),
                    StateCode = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Project", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermission",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false),
                    Scheme = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermission", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PasswordSalt = table.Column<string>(nullable: true),
                    PasswordHash = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ModifiedOn = table.Column<DateTime>(nullable: true),
                    CreatedBy = table.Column<Guid>(nullable: true),
                    ModifiedBy = table.Column<Guid>(nullable: true),
                    StatusCode = table.Column<short>(nullable: false),
                    StateCode = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Version",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    ProjectId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    DirectoryPath = table.Column<string>(nullable: true),
                    PreviewFile = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    ModifiedOn = table.Column<DateTime>(nullable: false),
                    CreatedBy = table.Column<Guid>(nullable: false),
                    ModifiedBy = table.Column<Guid>(nullable: false),
                    StatusCode = table.Column<short>(nullable: false),
                    StateCode = table.Column<short>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Version", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "StateCode", "StatusCode" },
                values: new object[] { new Guid("5b4b1c85-090e-4e73-b407-d78a91553a50"), new Guid("cf572fea-7ee8-4f64-a69d-67718aee1035"), new DateTime(2020, 6, 7, 21, 0, 23, 986, DateTimeKind.Local).AddTicks(1905), new Guid("cf572fea-7ee8-4f64-a69d-67718aee1035"), new DateTime(2020, 6, 7, 21, 0, 23, 986, DateTimeKind.Local).AddTicks(1485), "Demo customer", (short)1, (short)1 });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerId", "Description", "ModifiedBy", "ModifiedOn", "Name", "ShortCode", "StateCode", "StatusCode" },
                values: new object[] { new Guid("f1f92350-29eb-4352-b0dd-309922638022"), new Guid("cf572fea-7ee8-4f64-a69d-67718aee1035"), new DateTime(2020, 6, 7, 21, 0, 23, 986, DateTimeKind.Local).AddTicks(4251), new Guid("5b4b1c85-090e-4e73-b407-d78a91553a50"), "Demo project", new Guid("cf572fea-7ee8-4f64-a69d-67718aee1035"), new DateTime(2020, 6, 7, 21, 0, 23, 986, DateTimeKind.Local).AddTicks(3870), "Demo project", "Demo-Project", (short)1, (short)1 });

            migrationBuilder.InsertData(
                table: "ProjectUser",
                columns: new[] { "Id", "ProjectId", "UserId" },
                values: new object[] { new Guid("234ce45d-ec15-4b0f-b237-c395b2ac9604"), new Guid("f1f92350-29eb-4352-b0dd-309922638022"), new Guid("cf572fea-7ee8-4f64-a69d-67718aee1035") });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("149acc02-9955-48de-82d8-bfd53df8dab7"), "Admin role", "Admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "RoleId", "Scheme" },
                values: new object[] { new Guid("69310072-b1d3-41cb-afd8-f89a86e6a051"), new Guid("149acc02-9955-48de-82d8-bfd53df8dab7"), "user/get" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedOn", "PasswordHash", "PasswordSalt", "StateCode", "StatusCode" },
                values: new object[] { new Guid("cf572fea-7ee8-4f64-a69d-67718aee1035"), new Guid("cf572fea-7ee8-4f64-a69d-67718aee1035"), new DateTime(2020, 6, 7, 21, 0, 23, 985, DateTimeKind.Local).AddTicks(1680), "admin@test.com", "admin", "admin", new Guid("cf572fea-7ee8-4f64-a69d-67718aee1035"), new DateTime(2020, 6, 7, 21, 0, 23, 984, DateTimeKind.Local).AddTicks(4344), "Pe/GAkoysqFrrBJ9ECjYmzO0JH6Eu6Xae3YcY5Hld39noqbz8vvhTcZp+uZ5whfJuK+PBqNpIMEACVQc7ZDqXw==", "Pj8PdCe/AMmXEcpofLIwMQe487JOZKRUVj6+drP75QtaTazArhso+zE7IxN1ehtKD3ldJfJE9+Rta0knsQ9hOWBvZob6WJTIfdMW1vMy9LosGpc5VWWq1x3OFl9HiMqAz98rpS0oXd7woxZYjEFyyGyISCyLIMW+aFeqoXJq9jc=", (short)1, (short)1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("1ae9565f-0704-440f-91a3-a5063498b28b"), new Guid("149acc02-9955-48de-82d8-bfd53df8dab7"), new Guid("cf572fea-7ee8-4f64-a69d-67718aee1035") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");

            migrationBuilder.DropTable(
                name: "Project");

            migrationBuilder.DropTable(
                name: "ProjectUser");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "RolePermission");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Version");
        }
    }
}
