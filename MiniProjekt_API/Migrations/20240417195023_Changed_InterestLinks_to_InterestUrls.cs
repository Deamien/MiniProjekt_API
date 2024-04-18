using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniProjekt_API.Migrations
{
    /// <inheritdoc />
    public partial class Changed_InterestLinks_to_InterestUrls : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinks_Interests_InterestssId",
                table: "InterestLinks");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestLinks_People_PeopleeId",
                table: "InterestLinks");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestLinks",
                table: "InterestLinks");

            migrationBuilder.RenameTable(
                name: "InterestLinks",
                newName: "InterestUrls");

            migrationBuilder.RenameIndex(
                name: "IX_InterestLinks_PeopleeId",
                table: "InterestUrls",
                newName: "IX_InterestUrls_PeopleeId");

            migrationBuilder.RenameIndex(
                name: "IX_InterestLinks_InterestssId",
                table: "InterestUrls",
                newName: "IX_InterestUrls_InterestssId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestUrls",
                table: "InterestUrls",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestUrls_Interests_InterestssId",
                table: "InterestUrls",
                column: "InterestssId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestUrls_People_PeopleeId",
                table: "InterestUrls",
                column: "PeopleeId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InterestUrls_Interests_InterestssId",
                table: "InterestUrls");

            migrationBuilder.DropForeignKey(
                name: "FK_InterestUrls_People_PeopleeId",
                table: "InterestUrls");

            migrationBuilder.DropPrimaryKey(
                name: "PK_InterestUrls",
                table: "InterestUrls");

            migrationBuilder.RenameTable(
                name: "InterestUrls",
                newName: "InterestLinks");

            migrationBuilder.RenameIndex(
                name: "IX_InterestUrls_PeopleeId",
                table: "InterestLinks",
                newName: "IX_InterestLinks_PeopleeId");

            migrationBuilder.RenameIndex(
                name: "IX_InterestUrls_InterestssId",
                table: "InterestLinks",
                newName: "IX_InterestLinks_InterestssId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_InterestLinks",
                table: "InterestLinks",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinks_Interests_InterestssId",
                table: "InterestLinks",
                column: "InterestssId",
                principalTable: "Interests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_InterestLinks_People_PeopleeId",
                table: "InterestLinks",
                column: "PeopleeId",
                principalTable: "People",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
