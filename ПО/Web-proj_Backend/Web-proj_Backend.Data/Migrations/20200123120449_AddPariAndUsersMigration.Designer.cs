﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Web_proj_Backend.Data;

namespace Web_proj_Backend.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20200123120449_AddPariAndUsersMigration")]
    partial class AddPariAndUsersMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.SerialColumn)
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Web_proj_Backend.Models.Entities.Pari", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<DateTime>("Ending");

                    b.Property<int>("IdUser");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Paris");
                });
#pragma warning restore 612, 618
        }
    }
}
