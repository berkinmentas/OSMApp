using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "pointName",
                table: "Points",
                newName: "PointName");

            migrationBuilder.AddColumn<string>(
                name: "PointNumber",
                table: "Points",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PointNumber",
                table: "Points");

            migrationBuilder.RenameColumn(
                name: "PointName",
                table: "Points",
                newName: "pointName");
        }
    }
}
