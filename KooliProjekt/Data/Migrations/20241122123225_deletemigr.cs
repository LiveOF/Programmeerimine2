using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class deletemigr : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Structure_Client_ClientId",
                table: "Structure");

            migrationBuilder.DropIndex(
                name: "IX_Structure_ClientId",
                table: "Structure");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Structure");

            migrationBuilder.CreateIndex(
                name: "IX_Structure_Client_Ref",
                table: "Structure",
                column: "Client_Ref");

            migrationBuilder.AddForeignKey(
                name: "FK_Structure_Client_Client_Ref",
                table: "Structure",
                column: "Client_Ref",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Structure_Client_Client_Ref",
                table: "Structure");

            migrationBuilder.DropIndex(
                name: "IX_Structure_Client_Ref",
                table: "Structure");

            migrationBuilder.AddColumn<long>(
                name: "ClientId",
                table: "Structure",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Structure_ClientId",
                table: "Structure",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Structure_Client_ClientId",
                table: "Structure",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");
        }
    }
}
