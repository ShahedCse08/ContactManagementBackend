using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ContactGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactGroups", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GroupId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Contacts_ContactGroups_GroupId",
                        column: x => x.GroupId,
                        principalTable: "ContactGroups",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "ContactGroups",
                columns: new[] { "Id", "GroupName" },
                values: new object[,]
                {
                    { 1, "Family" },
                    { 2, "Friends" },
                    { 3, "Work" }
                });

            migrationBuilder.InsertData(
                table: "Contacts",
                columns: new[] { "Id", "ContactType", "GroupId", "Name", "PhoneNumber" },
                values: new object[,]
                {
                    { 1, "Mobile", 1, "John Doe", "123-456-7890" },
                    { 2, "Home", 2, "Jane Doe", "987-654-3210" },
                    { 3, "Work", 3, "Sam Smith", "555-666-7777" },
                    { 4, "Mobile", 1, "Alice Johnson", "111-222-3333" },
                    { 5, "Home", 2, "Bob Brown", "222-333-4444" },
                    { 6, "Work", 3, "Charlie White", "333-444-5555" },
                    { 7, "Mobile", 1, "David Black", "444-555-6666" },
                    { 8, "Home", 2, "Eve Green", "555-666-7777" },
                    { 9, "Work", 3, "Frank Red", "666-777-8888" },
                    { 10, "Mobile", 1, "Grace Blue", "777-888-9999" },
                    { 11, "Home", 2, "Henry Silver", "888-999-0000" },
                    { 12, "Work", 3, "Isla Gold", "999-000-1111" },
                    { 13, "Mobile", 1, "Jack Brown", "000-111-2222" },
                    { 14, "Home", 2, "Karen White", "111-222-3333" },
                    { 15, "Work", 3, "Leo Black", "222-333-4444" },
                    { 16, "Mobile", 1, "Mia Red", "333-444-5555" },
                    { 17, "Home", 2, "Nina Green", "444-555-6666" },
                    { 18, "Work", 3, "Oscar Blue", "555-666-7777" },
                    { 19, "Mobile", 1, "Peter Silver", "666-777-8888" },
                    { 20, "Home", 2, "Quinn Gold", "777-888-9999" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_GroupId",
                table: "Contacts",
                column: "GroupId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "ContactGroups");
        }
    }
}
