﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Wilcommerce.Catalog.Data.EFCore;

namespace Wilcommerce.Catalog.Data.EFCore.Migrations.Migrations
{
    [DbContext(typeof(CatalogContext))]
    partial class CatalogContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Wilcommerce.Catalog.Models.Brand", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("Url")
                        .IsUnique()
                        .HasFilter("[Url] IS NOT NULL");

                    b.ToTable("Wilcommerce_Brands");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsVisible")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ParentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("VisibleFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("VisibleTo")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasFilter("[Code] IS NOT NULL");

                    b.HasIndex("ParentId");

                    b.HasIndex("Url")
                        .IsUnique()
                        .HasFilter("[Url] IS NOT NULL");

                    b.ToTable("Wilcommerce_Categories");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.CustomAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("DataType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitOfMeasure")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_Values")
                        .HasColumnName("Values")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Wilcommerce_CustomAttributes");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("Deleted")
                        .HasColumnType("bit");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EanCode")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("IsOnSale")
                        .HasColumnType("bit");

                    b.Property<Guid?>("MainProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("OnSaleFrom")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("OnSaleTo")
                        .HasColumnType("datetime2");

                    b.Property<string>("Sku")
                        .HasColumnType("nvarchar(450)");

                    b.Property<bool>("TierPriceEnabled")
                        .HasColumnType("bit");

                    b.Property<int>("UnitInStock")
                        .HasColumnType("int");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid?>("VendorId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EanCode")
                        .IsUnique()
                        .HasFilter("[EanCode] IS NOT NULL");

                    b.HasIndex("MainProductId");

                    b.HasIndex("Sku")
                        .IsUnique()
                        .HasFilter("[Sku] IS NOT NULL");

                    b.HasIndex("Url")
                        .IsUnique()
                        .HasFilter("[Url] IS NOT NULL");

                    b.HasIndex("VendorId");

                    b.ToTable("Wilcommerce_Products");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.ProductAttribute", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AttributeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("_Value")
                        .HasColumnName("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.HasIndex("ProductId");

                    b.ToTable("Wilcommerce_ProductAttributes");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.ProductCategory", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.HasKey("ProductId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Wilcommerce_ProductCategories");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.ProductImage", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("OriginalName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("UploadedOn")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Wilcommerce_ProductImages");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.ProductReview", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("ApprovedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Comment")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Rating")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Wilcommerce_ProductReviews");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.TierPrice", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("FromQuantity")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProductId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ToQuantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("Wilcommerce_TierPrices");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.Brand", b =>
                {
                    b.OwnsOne("Wilcommerce.Core.Common.Models.Image", "Logo", b1 =>
                        {
                            b1.Property<Guid>("BrandId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<byte[]>("Data")
                                .HasColumnType("varbinary(max)");

                            b1.Property<string>("MimeType")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BrandId");

                            b1.ToTable("Wilcommerce_Brands");

                            b1.WithOwner()
                                .HasForeignKey("BrandId");
                        });

                    b.OwnsOne("Wilcommerce.Core.Common.Models.SeoData", "Seo", b1 =>
                        {
                            b1.Property<Guid>("BrandId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Keywords")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgAudio")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgDescription")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgDeterminer")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgImage")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgLocale")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgLocaleAlternate")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgSiteName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgTitle")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgType")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgVideo")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("BrandId");

                            b1.ToTable("Wilcommerce_Brands");

                            b1.WithOwner()
                                .HasForeignKey("BrandId");
                        });
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.Category", b =>
                {
                    b.HasOne("Wilcommerce.Catalog.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");

                    b.OwnsOne("Wilcommerce.Core.Common.Models.SeoData", "Seo", b1 =>
                        {
                            b1.Property<Guid>("CategoryId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Keywords")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgAudio")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgDescription")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgDeterminer")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgImage")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgLocale")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgLocaleAlternate")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgSiteName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgTitle")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgType")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgVideo")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("CategoryId");

                            b1.ToTable("Wilcommerce_Categories");

                            b1.WithOwner()
                                .HasForeignKey("CategoryId");
                        });
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.Product", b =>
                {
                    b.HasOne("Wilcommerce.Catalog.Models.Product", "MainProduct")
                        .WithMany("Variants")
                        .HasForeignKey("MainProductId");

                    b.HasOne("Wilcommerce.Catalog.Models.Brand", "Vendor")
                        .WithMany()
                        .HasForeignKey("VendorId");

                    b.OwnsOne("Wilcommerce.Core.Common.Models.Currency", "Price", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<string>("Code")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProductId");

                            b1.ToTable("Wilcommerce_Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });

                    b.OwnsOne("Wilcommerce.Core.Common.Models.SeoData", "Seo", b1 =>
                        {
                            b1.Property<Guid>("ProductId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Keywords")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgAudio")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgDescription")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgDeterminer")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgImage")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgLocale")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgLocaleAlternate")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgSiteName")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgTitle")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgType")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgUrl")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("OgVideo")
                                .HasColumnType("nvarchar(max)");

                            b1.Property<string>("Title")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("ProductId");

                            b1.ToTable("Wilcommerce_Products");

                            b1.WithOwner()
                                .HasForeignKey("ProductId");
                        });
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.ProductAttribute", b =>
                {
                    b.HasOne("Wilcommerce.Catalog.Models.CustomAttribute", "Attribute")
                        .WithMany()
                        .HasForeignKey("AttributeId");

                    b.HasOne("Wilcommerce.Catalog.Models.Product", "Product")
                        .WithMany("Attributes")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.ProductCategory", b =>
                {
                    b.HasOne("Wilcommerce.Catalog.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wilcommerce.Catalog.Models.Product", "Product")
                        .WithMany("ProductCategories")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.ProductImage", b =>
                {
                    b.HasOne("Wilcommerce.Catalog.Models.Product", "Product")
                        .WithMany("Images")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.ProductReview", b =>
                {
                    b.HasOne("Wilcommerce.Catalog.Models.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("Wilcommerce.Catalog.Models.TierPrice", b =>
                {
                    b.HasOne("Wilcommerce.Catalog.Models.Product", "Product")
                        .WithMany("TierPrices")
                        .HasForeignKey("ProductId");

                    b.OwnsOne("Wilcommerce.Core.Common.Models.Currency", "Price", b1 =>
                        {
                            b1.Property<Guid>("TierPriceId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<double>("Amount")
                                .HasColumnType("float");

                            b1.Property<string>("Code")
                                .HasColumnType("nvarchar(max)");

                            b1.HasKey("TierPriceId");

                            b1.ToTable("Wilcommerce_TierPrices");

                            b1.WithOwner()
                                .HasForeignKey("TierPriceId");
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
