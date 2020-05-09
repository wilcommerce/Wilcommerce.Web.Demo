using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Wilcommerce.Catalog.Data.EFCore.Migrations.Migrations
{
    public partial class CatalogInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Wilcommerce_Brands",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Logo_Data = table.Column<byte[]>(nullable: true),
                    Logo_MimeType = table.Column<string>(nullable: true),
                    Seo_Title = table.Column<string>(nullable: true),
                    Seo_Description = table.Column<string>(nullable: true),
                    Seo_Keywords = table.Column<string>(nullable: true),
                    Seo_OgTitle = table.Column<string>(nullable: true),
                    Seo_OgType = table.Column<string>(nullable: true),
                    Seo_OgImage = table.Column<string>(nullable: true),
                    Seo_OgUrl = table.Column<string>(nullable: true),
                    Seo_OgAudio = table.Column<string>(nullable: true),
                    Seo_OgDescription = table.Column<string>(nullable: true),
                    Seo_OgDeterminer = table.Column<string>(nullable: true),
                    Seo_OgLocale = table.Column<string>(nullable: true),
                    Seo_OgLocaleAlternate = table.Column<string>(nullable: true),
                    Seo_OgSiteName = table.Column<string>(nullable: true),
                    Seo_OgVideo = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilcommerce_Brands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wilcommerce_Categories",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Code = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    IsVisible = table.Column<bool>(nullable: false),
                    VisibleFrom = table.Column<DateTime>(nullable: true),
                    VisibleTo = table.Column<DateTime>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    ParentId = table.Column<Guid>(nullable: true),
                    Seo_Title = table.Column<string>(nullable: true),
                    Seo_Description = table.Column<string>(nullable: true),
                    Seo_Keywords = table.Column<string>(nullable: true),
                    Seo_OgTitle = table.Column<string>(nullable: true),
                    Seo_OgType = table.Column<string>(nullable: true),
                    Seo_OgImage = table.Column<string>(nullable: true),
                    Seo_OgUrl = table.Column<string>(nullable: true),
                    Seo_OgAudio = table.Column<string>(nullable: true),
                    Seo_OgDescription = table.Column<string>(nullable: true),
                    Seo_OgDeterminer = table.Column<string>(nullable: true),
                    Seo_OgLocale = table.Column<string>(nullable: true),
                    Seo_OgLocaleAlternate = table.Column<string>(nullable: true),
                    Seo_OgSiteName = table.Column<string>(nullable: true),
                    Seo_OgVideo = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilcommerce_Categories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wilcommerce_Categories_Wilcommerce_Categories_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Wilcommerce_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wilcommerce_CustomAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    UnitOfMeasure = table.Column<string>(nullable: true),
                    DataType = table.Column<string>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    Values = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilcommerce_CustomAttributes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Wilcommerce_Products",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    EanCode = table.Column<string>(nullable: true),
                    Sku = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Url = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Price_Code = table.Column<string>(nullable: true),
                    Price_Amount = table.Column<double>(nullable: true),
                    UnitInStock = table.Column<int>(nullable: false),
                    IsOnSale = table.Column<bool>(nullable: false),
                    OnSaleFrom = table.Column<DateTime>(nullable: true),
                    OnSaleTo = table.Column<DateTime>(nullable: true),
                    MainProductId = table.Column<Guid>(nullable: true),
                    VendorId = table.Column<Guid>(nullable: true),
                    Deleted = table.Column<bool>(nullable: false),
                    TierPriceEnabled = table.Column<bool>(nullable: false),
                    Seo_Title = table.Column<string>(nullable: true),
                    Seo_Description = table.Column<string>(nullable: true),
                    Seo_Keywords = table.Column<string>(nullable: true),
                    Seo_OgTitle = table.Column<string>(nullable: true),
                    Seo_OgType = table.Column<string>(nullable: true),
                    Seo_OgImage = table.Column<string>(nullable: true),
                    Seo_OgUrl = table.Column<string>(nullable: true),
                    Seo_OgAudio = table.Column<string>(nullable: true),
                    Seo_OgDescription = table.Column<string>(nullable: true),
                    Seo_OgDeterminer = table.Column<string>(nullable: true),
                    Seo_OgLocale = table.Column<string>(nullable: true),
                    Seo_OgLocaleAlternate = table.Column<string>(nullable: true),
                    Seo_OgSiteName = table.Column<string>(nullable: true),
                    Seo_OgVideo = table.Column<string>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilcommerce_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wilcommerce_Products_Wilcommerce_Products_MainProductId",
                        column: x => x.MainProductId,
                        principalTable: "Wilcommerce_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wilcommerce_Products_Wilcommerce_Brands_VendorId",
                        column: x => x.VendorId,
                        principalTable: "Wilcommerce_Brands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wilcommerce_ProductAttributes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true),
                    AttributeId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilcommerce_ProductAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wilcommerce_ProductAttributes_Wilcommerce_CustomAttributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Wilcommerce_CustomAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Wilcommerce_ProductAttributes_Wilcommerce_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Wilcommerce_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wilcommerce_ProductCategories",
                columns: table => new
                {
                    ProductId = table.Column<Guid>(nullable: false),
                    CategoryId = table.Column<Guid>(nullable: false),
                    IsMain = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilcommerce_ProductCategories", x => new { x.ProductId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_Wilcommerce_ProductCategories_Wilcommerce_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Wilcommerce_Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Wilcommerce_ProductCategories_Wilcommerce_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Wilcommerce_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wilcommerce_ProductImages",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Path = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    OriginalName = table.Column<string>(nullable: true),
                    IsMain = table.Column<bool>(nullable: false),
                    UploadedOn = table.Column<DateTime>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilcommerce_ProductImages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wilcommerce_ProductImages_Wilcommerce_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Wilcommerce_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wilcommerce_ProductReviews",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Rating = table.Column<int>(nullable: false),
                    Comment = table.Column<string>(nullable: true),
                    Approved = table.Column<bool>(nullable: false),
                    ApprovedOn = table.Column<DateTime>(nullable: true),
                    CreationDate = table.Column<DateTime>(nullable: false),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilcommerce_ProductReviews", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wilcommerce_ProductReviews_Wilcommerce_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Wilcommerce_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Wilcommerce_TierPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    FromQuantity = table.Column<int>(nullable: false),
                    ToQuantity = table.Column<int>(nullable: false),
                    Price_Code = table.Column<string>(nullable: true),
                    Price_Amount = table.Column<double>(nullable: true),
                    ProductId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wilcommerce_TierPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wilcommerce_TierPrices_Wilcommerce_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Wilcommerce_Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_Brands_Url",
                table: "Wilcommerce_Brands",
                column: "Url",
                unique: true,
                filter: "[Url] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_Categories_Code",
                table: "Wilcommerce_Categories",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_Categories_ParentId",
                table: "Wilcommerce_Categories",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_Categories_Url",
                table: "Wilcommerce_Categories",
                column: "Url",
                unique: true,
                filter: "[Url] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_ProductAttributes_AttributeId",
                table: "Wilcommerce_ProductAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_ProductAttributes_ProductId",
                table: "Wilcommerce_ProductAttributes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_ProductCategories_CategoryId",
                table: "Wilcommerce_ProductCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_ProductImages_ProductId",
                table: "Wilcommerce_ProductImages",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_ProductReviews_ProductId",
                table: "Wilcommerce_ProductReviews",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_Products_EanCode",
                table: "Wilcommerce_Products",
                column: "EanCode",
                unique: true,
                filter: "[EanCode] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_Products_MainProductId",
                table: "Wilcommerce_Products",
                column: "MainProductId");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_Products_Sku",
                table: "Wilcommerce_Products",
                column: "Sku",
                unique: true,
                filter: "[Sku] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_Products_Url",
                table: "Wilcommerce_Products",
                column: "Url",
                unique: true,
                filter: "[Url] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_Products_VendorId",
                table: "Wilcommerce_Products",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_Wilcommerce_TierPrices_ProductId",
                table: "Wilcommerce_TierPrices",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Wilcommerce_ProductAttributes");

            migrationBuilder.DropTable(
                name: "Wilcommerce_ProductCategories");

            migrationBuilder.DropTable(
                name: "Wilcommerce_ProductImages");

            migrationBuilder.DropTable(
                name: "Wilcommerce_ProductReviews");

            migrationBuilder.DropTable(
                name: "Wilcommerce_TierPrices");

            migrationBuilder.DropTable(
                name: "Wilcommerce_CustomAttributes");

            migrationBuilder.DropTable(
                name: "Wilcommerce_Categories");

            migrationBuilder.DropTable(
                name: "Wilcommerce_Products");

            migrationBuilder.DropTable(
                name: "Wilcommerce_Brands");
        }
    }
}
