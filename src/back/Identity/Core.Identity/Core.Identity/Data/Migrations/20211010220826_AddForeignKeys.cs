using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Identity.Data.Migrations
{
    public partial class AddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Warriors",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Class_Id",
                table: "Subclasses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Subclasses",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Classes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Warriors_Class_Id",
                table: "Warriors",
                column: "Class_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Warriors_Subclass_Id",
                table: "Warriors",
                column: "Subclass_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Warriors_UserId",
                table: "Warriors",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Subclasses_Class_Id",
                table: "Subclasses",
                column: "Class_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Subclasses_Classes_Class_Id",
                table: "Subclasses",
                column: "Class_Id",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Warriors_AspNetUsers_UserId",
                table: "Warriors",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Warriors_Classes_Class_Id",
                table: "Warriors",
                column: "Class_Id",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Warriors_Subclasses_Subclass_Id",
                table: "Warriors",
                column: "Subclass_Id",
                principalTable: "Subclasses",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subclasses_Classes_Class_Id",
                table: "Subclasses");

            migrationBuilder.DropForeignKey(
                name: "FK_Warriors_AspNetUsers_UserId",
                table: "Warriors");

            migrationBuilder.DropForeignKey(
                name: "FK_Warriors_Classes_Class_Id",
                table: "Warriors");

            migrationBuilder.DropForeignKey(
                name: "FK_Warriors_Subclasses_Subclass_Id",
                table: "Warriors");

            migrationBuilder.DropIndex(
                name: "IX_Warriors_Class_Id",
                table: "Warriors");

            migrationBuilder.DropIndex(
                name: "IX_Warriors_Subclass_Id",
                table: "Warriors");

            migrationBuilder.DropIndex(
                name: "IX_Warriors_UserId",
                table: "Warriors");

            migrationBuilder.DropIndex(
                name: "IX_Subclasses_Class_Id",
                table: "Subclasses");

            migrationBuilder.DropColumn(
                name: "Class_Id",
                table: "Subclasses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Subclasses");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Classes");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                table: "Warriors",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);
        }
    }
}
