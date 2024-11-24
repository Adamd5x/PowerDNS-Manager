using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hiPower.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_ServerLocation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Region = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PostalCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ServerLocation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "T_Server",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Proto = table.Column<string>(type: "character varying(10)", maxLength: 10, precision: 0, scale: 5, nullable: false),
                    HostAddress = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: false),
                    Port = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Version = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    ApiKey = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Auth = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    OS = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Configuration = table.Column<string>(type: "text", nullable: true),
                    State = table.Column<int>(type: "integer", precision: 0, scale: 3, nullable: false),
                    Timeout = table.Column<int>(type: "integer", precision: 0, scale: 5, nullable: false),
                    Retries = table.Column<int>(type: "integer", precision: 0, scale: 2, nullable: false),
                    LocationId = table.Column<string>(type: "character varying(32)", maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_Server", x => x.Id);
                    table.ForeignKey(
                        name: "FK_T_Server_T_ServerLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "T_ServerLocation",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_Server_LocationId",
                table: "T_Server",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_T_ServerLocation_Name",
                table: "T_ServerLocation",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_Server");

            migrationBuilder.DropTable(
                name: "T_ServerLocation");
        }
    }
}
