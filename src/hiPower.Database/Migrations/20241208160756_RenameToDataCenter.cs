using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hiPower.Database.Migrations
{
    /// <inheritdoc />
    public partial class RenameToDataCenter : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_ServiceDetails_T_ServiceLocation_LocationId",
                table: "T_ServiceDetails");

            migrationBuilder.DropTable(
                name: "T_ServiceLocation");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "T_ServiceDetails",
                newName: "DataCenterId");

            migrationBuilder.RenameIndex(
                name: "IX_T_ServiceDetails_LocationId",
                table: "T_ServiceDetails",
                newName: "IX_T_ServiceDetails_DataCenterId");

            migrationBuilder.CreateTable(
                name: "T_DataCenter",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
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
                    table.PrimaryKey("PK_T_DataCenter", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "T_DataCenter",
                columns: new[] { "Id", "Address", "City", "Country", "Description", "Name", "PostalCode", "Region" },
                values: new object[] { "7EB5999F-AEF5-11EF-9FD9-47F022E22A50", "", "", "Default", "Initial location", "Default", "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_T_DataCenter_Name",
                table: "T_DataCenter",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_T_ServiceDetails_T_DataCenter_DataCenterId",
                table: "T_ServiceDetails",
                column: "DataCenterId",
                principalTable: "T_DataCenter",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_T_ServiceDetails_T_DataCenter_DataCenterId",
                table: "T_ServiceDetails");

            migrationBuilder.DropTable(
                name: "T_DataCenter");

            migrationBuilder.RenameColumn(
                name: "DataCenterId",
                table: "T_ServiceDetails",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_T_ServiceDetails_DataCenterId",
                table: "T_ServiceDetails",
                newName: "IX_T_ServiceDetails_LocationId");

            migrationBuilder.CreateTable(
                name: "T_ServiceLocation",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(36)", maxLength: 36, nullable: false),
                    Address = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    City = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "character varying(250)", maxLength: 250, nullable: true),
                    Name = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    PostalCode = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Region = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_ServiceLocation", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "T_ServiceLocation",
                columns: new[] { "Id", "Address", "City", "Country", "Description", "Name", "PostalCode", "Region" },
                values: new object[] { "7EB5999F-AEF5-11EF-9FD9-47F022E22A50", "", "", "Default", "Initial location", "Default", "", "" });

            migrationBuilder.CreateIndex(
                name: "IX_T_ServiceLocation_Name",
                table: "T_ServiceLocation",
                column: "Name");

            migrationBuilder.AddForeignKey(
                name: "FK_T_ServiceDetails_T_ServiceLocation_LocationId",
                table: "T_ServiceDetails",
                column: "LocationId",
                principalTable: "T_ServiceLocation",
                principalColumn: "Id");
        }
    }
}
