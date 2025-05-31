using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AspnetRun.Web.Migrations
{
    public partial class _UpdateModelCommonField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Wishlist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Wishlist",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Wishlist",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Wishlist",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Tag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Tag",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Tag",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Specification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Specification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Specification",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Specification",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Review",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Review",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Product",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Product",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "OrderItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "OrderItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Order",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "List",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "List",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "List",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "List",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Contact",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Contact",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Contact",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Compare",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Compare",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Compare",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Compare",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Category",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "CartItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "CartItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "CartItem",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "CartItem",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Cart",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Cart",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Cart",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreatedBy",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Blog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "ModifiedBy",
                table: "Blog",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Blog",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Wishlist");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Tag");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Specification");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Specification");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Specification");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Specification");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Review");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "OrderItem");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "List");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "List");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "List");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "List");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Contact");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Compare");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Compare");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Compare");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Compare");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "CartItem");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Cart");

            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "ModifiedBy",
                table: "Blog");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Blog");
        }
    }
}
