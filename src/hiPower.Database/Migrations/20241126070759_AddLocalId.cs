using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace hiPower.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LocalId",
                table: "T_Server",
                type: "character varying(250)",
                maxLength: 250,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LocalId",
                table: "T_Server");
        }
    }
}
