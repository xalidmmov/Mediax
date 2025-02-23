using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Mediax.Dal.Migrations
{
    /// <inheritdoc />
    public partial class changedn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Apointment",
                table: "Apointment");

            migrationBuilder.RenameTable(
                name: "Apointment",
                newName: "Apointsments");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apointsments",
                table: "Apointsments",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Apointsments",
                table: "Apointsments");

            migrationBuilder.RenameTable(
                name: "Apointsments",
                newName: "Apointment");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Apointment",
                table: "Apointment",
                column: "Id");
        }
    }
}
