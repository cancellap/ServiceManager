using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SM.Infra.Migrations
{
    /// <inheritdoc />
    public partial class teste : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoSede_Clientes_ClienteId",
                table: "EnderecoSede");

            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoSede_Endereco_EnderecoId",
                table: "EnderecoSede");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoSede",
                table: "EnderecoSede");

            migrationBuilder.RenameTable(
                name: "EnderecoSede",
                newName: "EnderecoSedes");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecoSede_EnderecoId",
                table: "EnderecoSedes",
                newName: "IX_EnderecoSedes_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecoSede_ClienteId",
                table: "EnderecoSedes",
                newName: "IX_EnderecoSedes_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoSedes",
                table: "EnderecoSedes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoSedes_Clientes_ClienteId",
                table: "EnderecoSedes",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoSedes_Endereco_EnderecoId",
                table: "EnderecoSedes",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoSedes_Clientes_ClienteId",
                table: "EnderecoSedes");

            migrationBuilder.DropForeignKey(
                name: "FK_EnderecoSedes_Endereco_EnderecoId",
                table: "EnderecoSedes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoSedes",
                table: "EnderecoSedes");

            migrationBuilder.RenameTable(
                name: "EnderecoSedes",
                newName: "EnderecoSede");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecoSedes_EnderecoId",
                table: "EnderecoSede",
                newName: "IX_EnderecoSede_EnderecoId");

            migrationBuilder.RenameIndex(
                name: "IX_EnderecoSedes_ClienteId",
                table: "EnderecoSede",
                newName: "IX_EnderecoSede_ClienteId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoSede",
                table: "EnderecoSede",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoSede_Clientes_ClienteId",
                table: "EnderecoSede",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EnderecoSede_Endereco_EnderecoId",
                table: "EnderecoSede",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
