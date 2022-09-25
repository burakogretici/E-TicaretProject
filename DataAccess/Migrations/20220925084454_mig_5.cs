using Microsoft.EntityFrameworkCore.Migrations;

namespace DataAccess.Migrations
{
    public partial class mig_5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims");

            migrationBuilder.DropIndex(
                name: "IX_UserOperationClaims_UserId",
                table: "UserOperationClaims");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserOperationClaims",
                table: "UserOperationClaims",
                columns: new[] { "UserId", "OperationClaimId" });
        }
    }
}
