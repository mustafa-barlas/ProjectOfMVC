using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccessLayer.Migrations
{
    public partial class mig_content_writerID_add : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WriterID",
                table: "Contents",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Contents_WriterID",
                table: "Contents",
                column: "WriterID");

            migrationBuilder.AddForeignKey(
                name: "FK_Contents_Writers_WriterID",
                table: "Contents",
                column: "WriterID",
                principalTable: "Writers",
                principalColumn: "WriterID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contents_Writers_WriterID",
                table: "Contents");

            migrationBuilder.DropIndex(
                name: "IX_Contents_WriterID",
                table: "Contents");

            migrationBuilder.DropColumn(
                name: "WriterID",
                table: "Contents");
        }
    }
}
