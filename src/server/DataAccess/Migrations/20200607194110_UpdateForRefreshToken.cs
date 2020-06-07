using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class UpdateForRefreshToken : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("5b4b1c85-090e-4e73-b407-d78a91553a50"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("f1f92350-29eb-4352-b0dd-309922638022"));

            migrationBuilder.DeleteData(
                table: "ProjectUser",
                keyColumn: "Id",
                keyValue: new Guid("234ce45d-ec15-4b0f-b237-c395b2ac9604"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("149acc02-9955-48de-82d8-bfd53df8dab7"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("69310072-b1d3-41cb-afd8-f89a86e6a051"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("cf572fea-7ee8-4f64-a69d-67718aee1035"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("1ae9565f-0704-440f-91a3-a5063498b28b"));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryDate",
                table: "User",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "ModifiedBy", "ModifiedOn", "Name", "StateCode", "StatusCode" },
                values: new object[] { new Guid("093db73c-11d7-4860-91d8-977b5d719f8d"), new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"), new DateTime(2020, 6, 7, 22, 41, 10, 69, DateTimeKind.Local).AddTicks(5008), new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"), new DateTime(2020, 6, 7, 22, 41, 10, 69, DateTimeKind.Local).AddTicks(4584), "Demo customer", (short)1, (short)1 });

            migrationBuilder.InsertData(
                table: "Project",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "CustomerId", "Description", "ModifiedBy", "ModifiedOn", "Name", "ShortCode", "StateCode", "StatusCode" },
                values: new object[] { new Guid("fe2a33d6-00f4-4676-aa77-a159f360ff1e"), new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"), new DateTime(2020, 6, 7, 22, 41, 10, 69, DateTimeKind.Local).AddTicks(7395), new Guid("093db73c-11d7-4860-91d8-977b5d719f8d"), "Demo project", new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"), new DateTime(2020, 6, 7, 22, 41, 10, 69, DateTimeKind.Local).AddTicks(7005), "Demo project", "Demo-Project", (short)1, (short)1 });

            migrationBuilder.InsertData(
                table: "ProjectUser",
                columns: new[] { "Id", "ProjectId", "UserId" },
                values: new object[] { new Guid("6c2bf836-c4ef-497a-b7f5-dc8b0487dd74"), new Guid("fe2a33d6-00f4-4676-aa77-a159f360ff1e"), new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819") });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { new Guid("59343ec3-965d-43e6-b60e-cc6fcd2e9160"), "Admin role", "Admin" });

            migrationBuilder.InsertData(
                table: "RolePermission",
                columns: new[] { "Id", "RoleId", "Scheme" },
                values: new object[] { new Guid("0622eb96-98e3-43cd-8232-ec4fb4f88936"), new Guid("59343ec3-965d-43e6-b60e-cc6fcd2e9160"), "user/get" });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "CreatedBy", "CreatedOn", "Email", "FirstName", "LastName", "ModifiedBy", "ModifiedOn", "PasswordHash", "PasswordSalt", "RefreshToken", "RefreshTokenExpiryDate", "StateCode", "StatusCode" },
                values: new object[] { new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"), new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"), new DateTime(2020, 6, 7, 22, 41, 10, 68, DateTimeKind.Local).AddTicks(5066), "admin@test.com", "admin", "admin", new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"), new DateTime(2020, 6, 7, 22, 41, 10, 67, DateTimeKind.Local).AddTicks(8311), "Pe/GAkoysqFrrBJ9ECjYmzO0JH6Eu6Xae3YcY5Hld39noqbz8vvhTcZp+uZ5whfJuK+PBqNpIMEACVQc7ZDqXw==", "Pj8PdCe/AMmXEcpofLIwMQe487JOZKRUVj6+drP75QtaTazArhso+zE7IxN1ehtKD3ldJfJE9+Rta0knsQ9hOWBvZob6WJTIfdMW1vMy9LosGpc5VWWq1x3OFl9HiMqAz98rpS0oXd7woxZYjEFyyGyISCyLIMW+aFeqoXJq9jc=", null, null, (short)1, (short)1 });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "UserId" },
                values: new object[] { new Guid("f6b40ffd-c6de-444a-857f-9d942070af3c"), new Guid("59343ec3-965d-43e6-b60e-cc6fcd2e9160"), new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customer",
                keyColumn: "Id",
                keyValue: new Guid("093db73c-11d7-4860-91d8-977b5d719f8d"));

            migrationBuilder.DeleteData(
                table: "Project",
                keyColumn: "Id",
                keyValue: new Guid("fe2a33d6-00f4-4676-aa77-a159f360ff1e"));

            migrationBuilder.DeleteData(
                table: "ProjectUser",
                keyColumn: "Id",
                keyValue: new Guid("6c2bf836-c4ef-497a-b7f5-dc8b0487dd74"));

            migrationBuilder.DeleteData(
                table: "Role",
                keyColumn: "Id",
                keyValue: new Guid("59343ec3-965d-43e6-b60e-cc6fcd2e9160"));

            migrationBuilder.DeleteData(
                table: "RolePermission",
                keyColumn: "Id",
                keyValue: new Guid("0622eb96-98e3-43cd-8232-ec4fb4f88936"));

            migrationBuilder.DeleteData(
                table: "User",
                keyColumn: "Id",
                keyValue: new Guid("fe039f76-d20e-4d89-bf2c-d0da49142819"));

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumn: "Id",
                keyValue: new Guid("f6b40ffd-c6de-444a-857f-9d942070af3c"));

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryDate",
                table: "User");

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
    }
}
