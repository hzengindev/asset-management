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
                    Name = table.Column<string>(maxLength: 100, nullable: false),
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
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    ShortCode = table.Column<string>(maxLength: 100, nullable: false),
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
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false)
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
                    Scheme = table.Column<string>(maxLength: 200, nullable: false)
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
                    FirstName = table.Column<string>(maxLength: 100, nullable: false),
                    LastName = table.Column<string>(maxLength: 100, nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    PasswordSalt = table.Column<string>(maxLength: 1000, nullable: false),
                    PasswordHash = table.Column<string>(maxLength: 1000, nullable: false),
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
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: false),
                    ProjectId = table.Column<Guid>(nullable: false),
                    CustomerId = table.Column<Guid>(nullable: false),
                    DirectoryPath = table.Column<string>(maxLength: 1000, nullable: false),
                    PreviewFile = table.Column<string>(maxLength: 1000, nullable: false),
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
                values: new object[] { new Guid("1d9cc685-2d46-455c-9d5c-e83135070926"), new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"), new DateTime(2020, 4, 12, 17, 34, 16, 802, DateTimeKind.Local).AddTicks(4136), new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"), new DateTime(2020, 4, 12, 17, 34, 16, 802, DateTimeKind.Local).AddTicks(3358), "Demo customer", (short)1, (short)1 });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerId", "Description", "ModifiedBy", "ModifiedOn", "Name", "ShortCode", "StateCode", "StatusCode" },
                values: new object[] { new Guid("5ae7c4b7-3059-481f-8d6b-d4fec0bfff80"), new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"), new DateTime(2020, 4, 12, 17, 34, 16, 802, DateTimeKind.Local).AddTicks(8748), new Guid("1d9cc685-2d46-455c-9d5c-e83135070926"), "Demo project", new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"), new DateTime(2020, 4, 12, 17, 34, 16, 802, DateTimeKind.Local).AddTicks(8001), "Demo project", "Demo-Project", (short)1, (short)1 });

            migrationBuilder.InsertData(
                table: "ProjectUser",
                columns: new[] { "Id", "ProjectId", "UserId" },
                values: new object[] { new Guid("becae929-47ac-4134-8c0b-665d0cc7b49b"), new Guid("5ae7c4b7-3059-481f-8d6b-d4fec0bfff80"), new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f") });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("fadb53a8-a759-4d9b-9729-994a6f55b33b"), "Admin role", "Admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "RoleId", "Scheme" },
                values: new object[] { new Guid("b9856ea2-f8ed-4ddb-971d-45acd4afb5b2"), new Guid("fadb53a8-a759-4d9b-9729-994a6f55b33b"), "user/get" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedOn", "PasswordHash", "PasswordSalt", "StateCode", "StatusCode" },
                values: new object[] { new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"), new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"), new DateTime(2020, 4, 12, 17, 34, 16, 801, DateTimeKind.Local).AddTicks(256), "admin@test.com", "admin", "admin", new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f"), new DateTime(2020, 4, 12, 17, 34, 16, 800, DateTimeKind.Local).AddTicks(1937), "Pe/GAkoysqFrrBJ9ECjYmzO0JH6Eu6Xae3YcY5Hld39noqbz8vvhTcZp+uZ5whfJuK+PBqNpIMEACVQc7ZDqXw==", "Pj8PdCe/AMmXEcpofLIwMQe487JOZKRUVj6+drP75QtaTazArhso+zE7IxN1ehtKD3ldJfJE9+Rta0knsQ9hOWBvZob6WJTIfdMW1vMy9LosGpc5VWWq1x3OFl9HiMqAz98rpS0oXd7woxZYjEFyyGyISCyLIMW+aFeqoXJq9jc=", (short)1, (short)1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("9da59431-2834-44df-aa9f-f6d598ce4fb6"), new Guid("fadb53a8-a759-4d9b-9729-994a6f55b33b"), new Guid("385b4ed0-eee0-4101-9e96-1388624ff53f") });
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
