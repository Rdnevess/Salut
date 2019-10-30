using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Salut.Infra.Data.Migrations
{
    public partial class aula38 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioId1",
                table: "Amigos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amigos",
                table: "Amigos");

            migrationBuilder.DropIndex(
                name: "IX_Amigos_UsuarioId1",
                table: "Amigos");

            migrationBuilder.DropColumn(
                name: "UsuarioId1",
                table: "Amigos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Amigos",
                nullable: false,
                oldClrType: typeof(int))
                .OldAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioAmigoId",
                table: "Amigos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amigos",
                table: "Amigos",
                columns: new[] { "UsuarioId", "UsuarioAmigoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioId",
                table: "Amigos",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioId",
                table: "Amigos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Amigos",
                table: "Amigos");

            migrationBuilder.DropColumn(
                name: "UsuarioAmigoId",
                table: "Amigos");

            migrationBuilder.AlterColumn<int>(
                name: "UsuarioId",
                table: "Amigos",
                nullable: false,
                oldClrType: typeof(int))
                .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

            migrationBuilder.AddColumn<int>(
                name: "UsuarioId1",
                table: "Amigos",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Amigos",
                table: "Amigos",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Amigos_UsuarioId1",
                table: "Amigos",
                column: "UsuarioId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Amigos_Usuarios_UsuarioId1",
                table: "Amigos",
                column: "UsuarioId1",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
