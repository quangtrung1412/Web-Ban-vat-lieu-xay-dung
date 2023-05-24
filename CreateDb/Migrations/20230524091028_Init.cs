using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CreateDb.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryCode = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: false),
                    CategoryName = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryCode);
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    OrderCode = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: false),
                    OrderDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TotalPrice = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Email = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Phone = table.Column<decimal>(type: "Number", maxLength: 10, nullable: false),
                    Address = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    Seller = table.Column<string>(type: "NVARCHAR2(50)", maxLength: 50, nullable: false),
                    Paid = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Sale = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Status = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.OrderCode);
                });

            migrationBuilder.CreateTable(
                name: "OrderDetail",
                columns: table => new
                {
                    OrderDetailCode = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: false),
                    OrderCode = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    ProductCode = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    ProductName = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    RetailPrice = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Unit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    NumberProduct = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    TotalPrice = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Sale = table.Column<long>(type: "NUMBER(19)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderDetail", x => x.OrderDetailCode);
                });

            migrationBuilder.CreateTable(
                name: "OrderingStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("OrderingStatus_pk", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductCode = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: false),
                    ProductName = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Image = table.Column<string>(type: "NVARCHAR2(10)", maxLength: 10, nullable: false),
                    Cost = table.Column<decimal>(type: "NUMBER(20,3)", nullable: false),
                    RetailPrice = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Inventory = table.Column<long>(type: "NUMBER(19)", nullable: false),
                    Unit = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    Status = table.Column<bool>(type: "NUMBER(1)", nullable: false),
                    CategoryName = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false),
                    TradeMarkName = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductCode);
                });

            migrationBuilder.CreateTable(
                name: "TradeMark",
                columns: table => new
                {
                    TradeMarkCode = table.Column<string>(type: "VARCHAR2(10)", unicode: false, maxLength: 10, nullable: false),
                    TradeMarkName = table.Column<string>(type: "NVARCHAR2(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TradeMark", x => x.TradeMarkCode);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "OrderDetail");

            migrationBuilder.DropTable(
                name: "OrderingStatus");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "TradeMark");
        }
    }
}
