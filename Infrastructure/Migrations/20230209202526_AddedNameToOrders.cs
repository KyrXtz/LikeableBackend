using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class AddedNameToOrders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSelectedItems_SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet_OrderId",
                table: "OrderSelectedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrders_SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet_OrderId",
                table: "UserOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet",
                table: "SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet");

            migrationBuilder.RenameTable(
                name: "SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet",
                newName: "Orders");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSelectedItems_Orders_OrderId",
                table: "OrderSelectedItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrders_Orders_OrderId",
                table: "UserOrders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderSelectedItems_Orders_OrderId",
                table: "OrderSelectedItems");

            migrationBuilder.DropForeignKey(
                name: "FK_UserOrders_Orders_OrderId",
                table: "UserOrders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet",
                table: "SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderSelectedItems_SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet_OrderId",
                table: "OrderSelectedItems",
                column: "OrderId",
                principalTable: "SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserOrders_SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet_OrderId",
                table: "UserOrders",
                column: "OrderId",
                principalTable: "SharedKernel.Interfaces.IAppDbContext<Domain.Aggregates.Order>.EntitySet",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
