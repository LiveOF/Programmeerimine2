using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace KooliProjekt.Data.Migrations
{
    /// <inheritdoc />
    public partial class _20241108 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelComponent_Component_ComponentId",
                table: "PanelComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_PanelComponent_PanelData_PanelDataId",
                table: "PanelComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Structure_StructureId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Structure_Client_ClientId",
                table: "Structure");

            migrationBuilder.DropForeignKey(
                name: "FK_StructurePanel_Structure_StructureId",
                table: "StructurePanel");

            migrationBuilder.AlterColumn<long>(
                name: "StructureId",
                table: "StructurePanel",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Structure",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "ClientId",
                table: "Structure",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "StructureId",
                table: "Services",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<long>(
                name: "PanelDataId",
                table: "PanelComponent",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "ComponentId",
                table: "PanelComponent",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Component",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Client",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelComponent_Component_ComponentId",
                table: "PanelComponent",
                column: "ComponentId",
                principalTable: "Component",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PanelComponent_PanelData_PanelDataId",
                table: "PanelComponent",
                column: "PanelDataId",
                principalTable: "PanelData",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Structure_StructureId",
                table: "Services",
                column: "StructureId",
                principalTable: "Structure",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Structure_Client_ClientId",
                table: "Structure",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StructurePanel_Structure_StructureId",
                table: "StructurePanel",
                column: "StructureId",
                principalTable: "Structure",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PanelComponent_Component_ComponentId",
                table: "PanelComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_PanelComponent_PanelData_PanelDataId",
                table: "PanelComponent");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Structure_StructureId",
                table: "Services");

            migrationBuilder.DropForeignKey(
                name: "FK_Structure_Client_ClientId",
                table: "Structure");

            migrationBuilder.DropForeignKey(
                name: "FK_StructurePanel_Structure_StructureId",
                table: "StructurePanel");

            migrationBuilder.AlterColumn<long>(
                name: "StructureId",
                table: "StructurePanel",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Location",
                table: "Structure",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ClientId",
                table: "Structure",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "StructureId",
                table: "Services",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Services",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PanelDataId",
                table: "PanelComponent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "ComponentId",
                table: "PanelComponent",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Component",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Client",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PanelComponent_Component_ComponentId",
                table: "PanelComponent",
                column: "ComponentId",
                principalTable: "Component",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PanelComponent_PanelData_PanelDataId",
                table: "PanelComponent",
                column: "PanelDataId",
                principalTable: "PanelData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Structure_StructureId",
                table: "Services",
                column: "StructureId",
                principalTable: "Structure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Structure_Client_ClientId",
                table: "Structure",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StructurePanel_Structure_StructureId",
                table: "StructurePanel",
                column: "StructureId",
                principalTable: "Structure",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
