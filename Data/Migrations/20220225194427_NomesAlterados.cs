using Microsoft.EntityFrameworkCore.Migrations;

namespace FourCars.Data.Migrations
{
    public partial class NomesAlterados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo");

            migrationBuilder.RenameTable(
                name: "Veiculo",
                newName: "TB_VEICULO");

            migrationBuilder.RenameColumn(
                name: "VeiculoId",
                table: "TB_VEICULO",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "TB_VEICULO",
                type: "nvarchar(55)",
                maxLength: 55,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_VEICULO",
                table: "TB_VEICULO",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_VEICULO",
                table: "TB_VEICULO");

            migrationBuilder.RenameTable(
                name: "TB_VEICULO",
                newName: "Veiculo");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Veiculo",
                newName: "VeiculoId");

            migrationBuilder.AlterColumn<string>(
                name: "Modelo",
                table: "Veiculo",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(55)",
                oldMaxLength: 55);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Veiculo",
                table: "Veiculo",
                column: "VeiculoId");
        }
    }
}
