using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EFDemo.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailAddress",
                schema: "ef",
                table: "Actors");

            migrationBuilder.CreateTable(
                name: "MoviePhotos",
                schema: "ef",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    MovieId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePhotos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MoviePhotos_Movies_MovieId",
                        column: x => x.MovieId,
                        principalSchema: "ef",
                        principalTable: "Movies",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                schema: "ef",
                table: "Actors",
                columns: new[] { "Id", "CreatedDate", "FirstName", "LastName", "ModifiedDate" },
                values: new object[,]
                {
                    { new Guid("0e0aeb30-94c1-4e0b-8bae-9d6c3c344ee2"), new DateTime(2025, 7, 7, 16, 14, 11, 986, DateTimeKind.Local).AddTicks(7289), "Kancı", "Poyrazoğlu", null },
                    { new Guid("0f8e97f4-30f2-4382-b6b2-e0e789e520b1"), new DateTime(2023, 12, 15, 17, 19, 15, 894, DateTimeKind.Local).AddTicks(7722), "Barımtay", "Çamdalı", null },
                    { new Guid("22e68d68-2f9d-473d-b998-e466ccc79b5f"), new DateTime(2023, 6, 18, 15, 39, 16, 250, DateTimeKind.Local).AddTicks(772), "Adıgüzel", "Poyrazoğlu", null },
                    { new Guid("2c78b2f0-fc2c-44fb-bd90-30ec96f7e3c1"), new DateTime(2022, 2, 27, 8, 42, 7, 124, DateTimeKind.Local).AddTicks(4481), "Bulmaz", "Yorulmaz", null },
                    { new Guid("2e0a1bf5-4234-4a4e-ab46-6b721e951089"), new DateTime(2021, 4, 2, 16, 22, 18, 102, DateTimeKind.Local).AddTicks(5469), "Beğbars", "Elçiboğa", null },
                    { new Guid("3287fdf8-856a-4dd3-b65e-1008ca55564c"), new DateTime(2021, 11, 28, 7, 15, 14, 676, DateTimeKind.Local).AddTicks(3695), "Buğrakarakağan", "Yazıcı", null },
                    { new Guid("35797c12-f99b-4254-bd83-d93740fd1a9f"), new DateTime(2023, 1, 30, 23, 33, 29, 774, DateTimeKind.Local).AddTicks(2726), "Karaca", "Adıvar", null },
                    { new Guid("37c6d1cb-d778-491e-addc-0a804cd1575b"), new DateTime(2022, 11, 4, 5, 43, 36, 183, DateTimeKind.Local).AddTicks(924), "Bağaalp", "Baturalp", null },
                    { new Guid("3bf818db-bad3-4cf0-85f5-3580310e9110"), new DateTime(2025, 3, 18, 3, 56, 22, 533, DateTimeKind.Local).AddTicks(2736), "Bongul", "Ertepınar", null },
                    { new Guid("421d4525-a5a5-4ca9-954c-126a9e319d28"), new DateTime(2024, 9, 12, 17, 4, 33, 467, DateTimeKind.Local).AddTicks(2739), "Baçman", "Özberk", null },
                    { new Guid("5d15fef0-e89c-4eb2-a19f-e607436f118e"), new DateTime(2022, 10, 29, 1, 35, 27, 128, DateTimeKind.Local).AddTicks(5726), "Bağtaş", "Atakol", null },
                    { new Guid("60d33f68-cd9c-4483-b420-27224623325d"), new DateTime(2021, 9, 24, 20, 9, 11, 271, DateTimeKind.Local).AddTicks(6718), "Bayrın", "Topaloğlu", null },
                    { new Guid("688cffe7-4199-43ff-b61d-bf1e0f7927ec"), new DateTime(2024, 6, 8, 9, 57, 36, 566, DateTimeKind.Local).AddTicks(8797), "Arsıl", "Berberoğlu", null },
                    { new Guid("afbb1190-f53b-48f8-b3f2-cbd36ee280e2"), new DateTime(2022, 12, 21, 10, 33, 30, 594, DateTimeKind.Local).AddTicks(4005), "Ilaçın", "Tunaboylu", null },
                    { new Guid("b47cf0da-4979-4c27-b1d5-c491f128809d"), new DateTime(2025, 9, 26, 13, 31, 14, 586, DateTimeKind.Local).AddTicks(9933), "Beğboğa", "Dizdar ", null },
                    { new Guid("bfaa5f01-fd24-457b-a844-26026904e52e"), new DateTime(2024, 8, 25, 19, 53, 38, 774, DateTimeKind.Local).AddTicks(3074), "Bozan", "Alnıaçık", null },
                    { new Guid("c3571b26-e811-4333-b98a-c7e2360c5c7d"), new DateTime(2025, 12, 8, 1, 20, 4, 647, DateTimeKind.Local).AddTicks(5024), "Baybiçen", "Doğan ", null },
                    { new Guid("c8f10a8f-b7c9-4efb-8c22-35213f9687d9"), new DateTime(2025, 10, 13, 19, 14, 14, 750, DateTimeKind.Local).AddTicks(5949), "Aşkın", "Yıldızoğlu", null },
                    { new Guid("cb5ee94a-0699-4818-b19e-331208b1849a"), new DateTime(2021, 2, 5, 1, 37, 38, 960, DateTimeKind.Local).AddTicks(1794), "Elti", "Öymen", null },
                    { new Guid("e1263d08-a954-482d-9a96-27f7b8f9312d"), new DateTime(2023, 8, 5, 0, 39, 4, 208, DateTimeKind.Local).AddTicks(259), "Ergenekatun", "Tekand", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviePhotos_MovieId",
                schema: "ef",
                table: "MoviePhotos",
                column: "MovieId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviePhotos",
                schema: "ef");

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("0e0aeb30-94c1-4e0b-8bae-9d6c3c344ee2"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("0f8e97f4-30f2-4382-b6b2-e0e789e520b1"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("22e68d68-2f9d-473d-b998-e466ccc79b5f"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("2c78b2f0-fc2c-44fb-bd90-30ec96f7e3c1"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("2e0a1bf5-4234-4a4e-ab46-6b721e951089"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("3287fdf8-856a-4dd3-b65e-1008ca55564c"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("35797c12-f99b-4254-bd83-d93740fd1a9f"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("37c6d1cb-d778-491e-addc-0a804cd1575b"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("3bf818db-bad3-4cf0-85f5-3580310e9110"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("421d4525-a5a5-4ca9-954c-126a9e319d28"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("5d15fef0-e89c-4eb2-a19f-e607436f118e"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("60d33f68-cd9c-4483-b420-27224623325d"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("688cffe7-4199-43ff-b61d-bf1e0f7927ec"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("afbb1190-f53b-48f8-b3f2-cbd36ee280e2"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("b47cf0da-4979-4c27-b1d5-c491f128809d"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("bfaa5f01-fd24-457b-a844-26026904e52e"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("c3571b26-e811-4333-b98a-c7e2360c5c7d"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("c8f10a8f-b7c9-4efb-8c22-35213f9687d9"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("cb5ee94a-0699-4818-b19e-331208b1849a"));

            migrationBuilder.DeleteData(
                schema: "ef",
                table: "Actors",
                keyColumn: "Id",
                keyValue: new Guid("e1263d08-a954-482d-9a96-27f7b8f9312d"));

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                schema: "ef",
                table: "Actors",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
