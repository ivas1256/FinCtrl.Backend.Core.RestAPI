﻿// <auto-generated />
using System;
using FinCtrl.Backend.Core.RestAPI.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FinCtrl.Backend.Core.RestAPI.Migrations
{
    [DbContext(typeof(FinCtrlDBContext))]
    partial class FinCtrlDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("FinCtrl.Backend.Core.RestAPI.DAL.Models.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryId"), 1L, 1);

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ParentCategoryCategoryId")
                        .HasColumnType("int");

                    b.HasKey("CategoryId");

                    b.HasIndex("ParentCategoryCategoryId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FinCtrl.Backend.Core.RestAPI.DAL.Models.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentId"), 1L, 1);

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PaymentCategoryCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentDescription")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaymentSourceId")
                        .HasColumnType("int");

                    b.Property<decimal>("PaymentSum")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("PaymentType")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("PaymentCategoryCategoryId");

                    b.HasIndex("PaymentSourceId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("FinCtrl.Backend.Core.RestAPI.DAL.Models.PaymentSource", b =>
                {
                    b.Property<int>("PaymentSourceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PaymentSourceId"), 1L, 1);

                    b.Property<int?>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentSourceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PaymentSourceId");

                    b.HasIndex("CategoryId");

                    b.ToTable("PaymentSources");
                });

            modelBuilder.Entity("FinCtrl.Backend.Core.RestAPI.DAL.Models.Category", b =>
                {
                    b.HasOne("FinCtrl.Backend.Core.RestAPI.DAL.Models.Category", "ParentCategory")
                        .WithMany()
                        .HasForeignKey("ParentCategoryCategoryId");

                    b.Navigation("ParentCategory");
                });

            modelBuilder.Entity("FinCtrl.Backend.Core.RestAPI.DAL.Models.Payment", b =>
                {
                    b.HasOne("FinCtrl.Backend.Core.RestAPI.DAL.Models.Category", "PaymentCategory")
                        .WithMany()
                        .HasForeignKey("PaymentCategoryCategoryId");

                    b.HasOne("FinCtrl.Backend.Core.RestAPI.DAL.Models.PaymentSource", "PaymentSource")
                        .WithMany("Payments")
                        .HasForeignKey("PaymentSourceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PaymentCategory");

                    b.Navigation("PaymentSource");
                });

            modelBuilder.Entity("FinCtrl.Backend.Core.RestAPI.DAL.Models.PaymentSource", b =>
                {
                    b.HasOne("FinCtrl.Backend.Core.RestAPI.DAL.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FinCtrl.Backend.Core.RestAPI.DAL.Models.PaymentSource", b =>
                {
                    b.Navigation("Payments");
                });
#pragma warning restore 612, 618
        }
    }
}
