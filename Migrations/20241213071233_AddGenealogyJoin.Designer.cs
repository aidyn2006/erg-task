﻿// <auto-generated />
using System;
using ERG_Task.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ERG_Task.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241213071233_AddGenealogyJoin")]
    partial class AddGenealogyJoin
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ERG_Task.Models.Event", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateEvent")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float?>("Final_Dimension_X")
                        .HasColumnType("real");

                    b.Property<float?>("Initial_Dimension_X")
                        .HasColumnType("real");

                    b.Property<int?>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("PackageId")
                        .HasColumnType("integer");

                    b.Property<int?>("ProductId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int?>("SupplyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.HasIndex("PackageId");

                    b.HasIndex("SupplyId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ERG_Task.Models.EventHistory", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Comment")
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateEvent")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModify")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("EventId")
                        .HasColumnType("integer");

                    b.Property<long?>("EventId1")
                        .HasColumnType("bigint");

                    b.Property<float>("Final_Dimension_X")
                        .HasColumnType("real");

                    b.Property<float>("Initial_Dimension_X")
                        .HasColumnType("real");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("PackageId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int>("SupplyId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("EventId1");

                    b.ToTable("EventHistories");
                });

            modelBuilder.Entity("ERG_Task.Models.Genealogy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<long?>("ChildEventId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<float>("DimensionX")
                        .HasColumnType("real");

                    b.Property<long>("EventChildId")
                        .HasColumnType("bigint");

                    b.Property<long>("EventParentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ParentEventId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EventChildId");

                    b.HasIndex("EventParentId");

                    b.ToTable("Genealogy");
                });

            modelBuilder.Entity("ERG_Task.Models.Invoice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateInvoice")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateShipping")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NumberInvoice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Invoices");
                });

            modelBuilder.Entity("ERG_Task.Models.InvoiceHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateInvoice")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModify")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("InvoiceId")
                        .HasColumnType("integer");

                    b.Property<string>("NumberInvoice")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("InvoiceId");

                    b.ToTable("InvoiceHistories");
                });

            modelBuilder.Entity("ERG_Task.Models.Package", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime?>("LoadingDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int?>("OrderInTrain")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentPackageId")
                        .HasColumnType("integer");

                    b.Property<int>("StatusId")
                        .HasColumnType("integer");

                    b.Property<int?>("TrainId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TrainId");

                    b.ToTable("Packages");
                });

            modelBuilder.Entity("ERG_Task.Models.PackageHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateModify")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<int>("OrderInTrain")
                        .HasColumnType("integer");

                    b.Property<int>("PackageId")
                        .HasColumnType("integer");

                    b.Property<int?>("ParentPackageId")
                        .HasColumnType("integer");

                    b.Property<int?>("TrainId")
                        .HasColumnType("integer");

                    b.Property<int>("TypeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("PackageId");

                    b.ToTable("PackageHistories");
                });

            modelBuilder.Entity("ERG_Task.Models.Supply", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Supplies");
                });

            modelBuilder.Entity("ERG_Task.Models.Train", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NameTrain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TrainStatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Trains");
                });

            modelBuilder.Entity("ERG_Task.Models.TrainHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("DateCreate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("DateModify")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("NameTrain")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TrainId")
                        .HasColumnType("integer");

                    b.Property<int>("TrainStatusId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TrainId");

                    b.ToTable("TrainHistories");
                });

            modelBuilder.Entity("ERG_Task.Models.Event", b =>
                {
                    b.HasOne("ERG_Task.Models.Invoice", null)
                        .WithMany("Events")
                        .HasForeignKey("InvoiceId");

                    b.HasOne("ERG_Task.Models.Package", null)
                        .WithMany("Events")
                        .HasForeignKey("PackageId");

                    b.HasOne("ERG_Task.Models.Supply", null)
                        .WithMany("Events")
                        .HasForeignKey("SupplyId");
                });

            modelBuilder.Entity("ERG_Task.Models.EventHistory", b =>
                {
                    b.HasOne("ERG_Task.Models.Event", null)
                        .WithMany("EventHistories")
                        .HasForeignKey("EventId1");
                });

            modelBuilder.Entity("ERG_Task.Models.Genealogy", b =>
                {
                    b.HasOne("ERG_Task.Models.Event", "EventChild")
                        .WithMany()
                        .HasForeignKey("EventChildId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ERG_Task.Models.Event", "EventParent")
                        .WithMany()
                        .HasForeignKey("EventParentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EventChild");

                    b.Navigation("EventParent");
                });

            modelBuilder.Entity("ERG_Task.Models.InvoiceHistory", b =>
                {
                    b.HasOne("ERG_Task.Models.Invoice", null)
                        .WithMany("InvoiceHistories")
                        .HasForeignKey("InvoiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERG_Task.Models.Package", b =>
                {
                    b.HasOne("ERG_Task.Models.Train", null)
                        .WithMany("Packages")
                        .HasForeignKey("TrainId");
                });

            modelBuilder.Entity("ERG_Task.Models.PackageHistory", b =>
                {
                    b.HasOne("ERG_Task.Models.Package", null)
                        .WithMany("Packages")
                        .HasForeignKey("PackageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERG_Task.Models.TrainHistory", b =>
                {
                    b.HasOne("ERG_Task.Models.Train", null)
                        .WithMany("TrainHistory")
                        .HasForeignKey("TrainId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ERG_Task.Models.Event", b =>
                {
                    b.Navigation("EventHistories");
                });

            modelBuilder.Entity("ERG_Task.Models.Invoice", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("InvoiceHistories");
                });

            modelBuilder.Entity("ERG_Task.Models.Package", b =>
                {
                    b.Navigation("Events");

                    b.Navigation("Packages");
                });

            modelBuilder.Entity("ERG_Task.Models.Supply", b =>
                {
                    b.Navigation("Events");
                });

            modelBuilder.Entity("ERG_Task.Models.Train", b =>
                {
                    b.Navigation("Packages");

                    b.Navigation("TrainHistory");
                });
#pragma warning restore 612, 618
        }
    }
}