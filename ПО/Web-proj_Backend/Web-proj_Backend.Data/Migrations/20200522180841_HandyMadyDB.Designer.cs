﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Web_proj_Backend.Data;

namespace Web_proj_Backend.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200522180841_HandyMadyDB")]
    partial class HandyMadyDB
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Goods", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("Cost");

                    b.Property<string>("Description");

                    b.Property<string>("Sale_name");

                    b.Property<int>("StoreId");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Positions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<int>("GoodId");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Purchases", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Date");

                    b.Property<int>("Full_price");

                    b.Property<int>("PositionId");

                    b.Property<int>("Rate_good");

                    b.Property<int>("Rate_store");

                    b.Property<int>("Status");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PositionId");

                    b.HasIndex("UserId");

                    b.ToTable("Purchases");
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Sales", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("GoodId");

                    b.Property<int>("Percent");

                    b.Property<string>("Sale_name");

                    b.Property<string>("Start");

                    b.Property<string>("Stop");

                    b.Property<int>("StoreId");

                    b.HasKey("Id");

                    b.HasIndex("GoodId");

                    b.HasIndex("StoreId");

                    b.ToTable("Sales");
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Stores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Store_name");

                    b.Property<int>("Type");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Subscriptions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("StoreId");

                    b.Property<int>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("StoreId");

                    b.HasIndex("UserId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Users", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Email");

                    b.Property<string>("Full_name");

                    b.Property<string>("Login");

                    b.Property<int>("Money");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<string>("Token");

                    b.HasKey("Id");

                    b.HasIndex("Login")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Goods", b =>
                {
                    b.HasOne("Web_proj_Backend.Models.Entities.Stores", "Store")
                        .WithMany("Goods")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Positions", b =>
                {
                    b.HasOne("Web_proj_Backend.Models.Entities.Goods", "Good")
                        .WithMany("Positions")
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Purchases", b =>
                {
                    b.HasOne("Web_proj_Backend.Models.Entities.Positions", "Position")
                        .WithMany("Purchase")
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Web_proj_Backend.Models.Entities.Users", "User")
                        .WithMany("Purchase")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Sales", b =>
                {
                    b.HasOne("Web_proj_Backend.Models.Entities.Goods", "Good")
                        .WithMany("Sales")
                        .HasForeignKey("GoodId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Web_proj_Backend.Models.Entities.Stores", "Store")
                        .WithMany("Sales")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Stores", b =>
                {
                    b.HasOne("Web_proj_Backend.Models.Entities.Users", "User")
                        .WithMany("Stores")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Subscriptions", b =>
                {
                    b.HasOne("Web_proj_Backend.Models.Entities.Stores", "Store")
                        .WithMany("Subscribe_List")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Web_proj_Backend.Models.Entities.Users", "User")
                        .WithMany("Subscribe_list")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
