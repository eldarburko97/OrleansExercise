using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OrleansExercise.Migrations
{
    
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "FirstName", "LastName", "Phone" },
                values: new object[,]
                {
                    { new Guid("ca7f0fc5-97c6-4b2c-809a-dba2dea629e4"), "Gradacacka 13", "Eldor", "Mujkic", "+387 61 764 891" },
                    { new Guid("1166210b-06e6-459b-81ef-49ea0ff2e021"), "Gradacacka 13", "Edo", "Mujkic", "+387 61 764 891" },
                    { new Guid("6b0cbae4-4d43-4cb0-aec5-a259640478c1"), "Gradacacka 13", "Faris", "Mujkic", "+387 61 764 891" },
                    { new Guid("37cb4f57-4066-46ef-9229-06880ea70bea"), "Gradacacka 13", "Kenan", "Mujkic", "+387 61 764 891" },
                    { new Guid("9cab3c3e-e793-4e5a-9460-732e2f2a68f9"), "Gradacacka 13", "Admir", "Mujkic", "+387 61 764 891" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("1166210b-06e6-459b-81ef-49ea0ff2e021"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("37cb4f57-4066-46ef-9229-06880ea70bea"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("6b0cbae4-4d43-4cb0-aec5-a259640478c1"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("9cab3c3e-e793-4e5a-9460-732e2f2a68f9"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("ca7f0fc5-97c6-4b2c-809a-dba2dea629e4"));
        }
    }
}
