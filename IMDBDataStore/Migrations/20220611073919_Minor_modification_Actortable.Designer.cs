﻿// <auto-generated />
using System;
using IMDBDataStore.Schema.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IMDBDataStore.Migrations
{
    [DbContext(typeof(IMDBContext))]
    [Migration("20220611073919_Minor_modification_Actortable")]
    partial class Minor_modification_Actortable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("IMDBDataStore.Schema.Models.Actor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Actors");
                });

            modelBuilder.Entity("IMDBDataStore.Schema.Models.Gender", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GenderType")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Gender");
                });

            modelBuilder.Entity("IMDBDataStore.Schema.Models.Movie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MovieName")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.Property<string>("Plot")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Poster")
                        .HasColumnType("varbinary(max)");

                    b.Property<int>("ProducerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("IMDBDataStore.Schema.Models.Producer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Bio")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CompanyName")
                        .HasColumnType("varchar(32)");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int?>("GenderId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(32)");

                    b.HasKey("Id");

                    b.HasIndex("GenderId");

                    b.ToTable("Producers");
                });

            modelBuilder.Entity("IMDBDataStore.Schema.Models.RolesInfo", b =>
                {
                    b.Property<Guid>("RolesId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("ActorsId")
                        .HasColumnType("int");

                    b.Property<int?>("MoviesId")
                        .HasColumnType("int");

                    b.HasKey("RolesId");

                    b.HasIndex("ActorsId");

                    b.HasIndex("MoviesId");

                    b.ToTable("RolesInfo");
                });

            modelBuilder.Entity("IMDBDataStore.Schema.Models.Actor", b =>
                {
                    b.HasOne("IMDBDataStore.Schema.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("IMDBDataStore.Schema.Models.Producer", b =>
                {
                    b.HasOne("IMDBDataStore.Schema.Models.Gender", "Gender")
                        .WithMany()
                        .HasForeignKey("GenderId");

                    b.Navigation("Gender");
                });

            modelBuilder.Entity("IMDBDataStore.Schema.Models.RolesInfo", b =>
                {
                    b.HasOne("IMDBDataStore.Schema.Models.Actor", "Actors")
                        .WithMany()
                        .HasForeignKey("ActorsId");

                    b.HasOne("IMDBDataStore.Schema.Models.Movie", "Movies")
                        .WithMany()
                        .HasForeignKey("MoviesId");

                    b.Navigation("Actors");

                    b.Navigation("Movies");
                });
#pragma warning restore 612, 618
        }
    }
}