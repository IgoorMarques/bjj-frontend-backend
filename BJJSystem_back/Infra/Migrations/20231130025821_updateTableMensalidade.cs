using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infra.Migrations
{
    /// <inheritdoc />
    public partial class updateTableMensalidade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "Mensalidade");

            migrationBuilder.AddColumn<bool>(
                name: "Pago",
                table: "Mensalidade",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Pago",
                table: "Mensalidade");

            migrationBuilder.AddColumn<string>(
                name: "Status",
                table: "Mensalidade",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
