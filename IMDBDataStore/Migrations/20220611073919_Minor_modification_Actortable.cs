using Microsoft.EntityFrameworkCore.Migrations;

namespace IMDBDataStore.Migrations
{
    public partial class Minor_modification_Actortable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Actors",
                type: "varchar(32)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "varchar(32)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "GenderId",
                table: "Actors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Actors_GenderId",
                table: "Actors",
                column: "GenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Actors_Gender_GenderId",
                table: "Actors",
                column: "GenderId",
                principalTable: "Gender",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Actors_Gender_GenderId",
                table: "Actors");

            migrationBuilder.DropIndex(
                name: "IX_Actors_GenderId",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "GenderId",
                table: "Actors");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Actors",
                type: "varchar(32)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(32)");
        }
    }
}
