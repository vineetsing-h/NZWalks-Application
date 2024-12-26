using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NZWalks.API.Migrations
{
    /// <inheritdoc />
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("45f803b0-8bba-4fdc-ac4e-b0397d4966e2"), "Medium" },
                    { new Guid("751882ce-03c1-41df-a7b3-f30065d26890"), "Easy" },
                    { new Guid("a242a8d7-65eb-4de7-971f-4292f6e71eb0"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("5c207a38-18e0-4a28-b4fd-2e5eb9157b9a"), "NTL", "Northland", null },
                    { new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"), "NSN", "Nelson", "https://images.pexels.com/photos/13918194/pexels-photo-13918194.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("9ddac940-5d19-461b-8bb8-6595b33a4851"), "WGN", "Wellington", "https://images.pexels.com/photos/4350631/pexels-photo-4350631.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("a5d08149-31b3-49f2-88fe-f28f182f8526"), "AKL", "Auckland", "https://images.pexels.com/photos/5169056/pexels-photo-5169056.jpeg?auto=compress&cs=tinysrgb&w=1260&h=750&dpr=1" },
                    { new Guid("cc573506-64ac-43f8-88d6-1a28132154bc"), "BOP", "Bay Of Plenty", null },
                    { new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"), "STL", "Southland", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("45f803b0-8bba-4fdc-ac4e-b0397d4966e2"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("751882ce-03c1-41df-a7b3-f30065d26890"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("a242a8d7-65eb-4de7-971f-4292f6e71eb0"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("5c207a38-18e0-4a28-b4fd-2e5eb9157b9a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("906cb139-415a-4bbb-a174-1a1faf9fb1f6"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9ddac940-5d19-461b-8bb8-6595b33a4851"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("a5d08149-31b3-49f2-88fe-f28f182f8526"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("cc573506-64ac-43f8-88d6-1a28132154bc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("f077a22e-4248-4bf6-b564-c7cf4e250263"));
        }
    }
}
