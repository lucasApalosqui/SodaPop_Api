﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SodaPop.Context;

namespace SodaPop.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20230510195511_Add_relationship_character_user")]
    partial class Add_relationship_character_user
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.17")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SodaPop.Models.Character", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_character")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CharacterName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("character_name");

                    b.Property<int>("IdPiece")
                        .HasColumnType("int")
                        .HasColumnName("id_piece");

                    b.Property<string>("ImageCharacter")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("image_character");

                    b.HasKey("Id");

                    b.HasIndex("IdPiece");

                    b.ToTable("Tbl_Character");
                });

            modelBuilder.Entity("SodaPop.Models.Piece", b =>
                {
                    b.Property<int>("IdPiece")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_piece")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("AverageScore")
                        .HasColumnType("float")
                        .HasColumnName("average_score");

                    b.Property<DateTime>("DatePublish")
                        .HasMaxLength(80)
                        .HasColumnType("datetime2")
                        .HasColumnName("date_publish");

                    b.Property<DateTime>("DateRelease")
                        .HasColumnType("datetime2")
                        .HasColumnName("date_release");

                    b.Property<string>("DescriptionPiece")
                        .HasMaxLength(400)
                        .HasColumnType("nvarchar(400)")
                        .HasColumnName("description_piece");

                    b.Property<string>("Director")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("director");

                    b.Property<string>("Duration")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("duration");

                    b.Property<string>("ImageBanner")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("image_banner");

                    b.Property<string>("ImageFront")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("image_front");

                    b.Property<string>("PieceName")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("piece_name");

                    b.Property<string>("Producer")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("producer");

                    b.HasKey("IdPiece");

                    b.ToTable("Tbl_Piece");
                });

            modelBuilder.Entity("SodaPop.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_user")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("AvatarUser")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("avatar_user");

                    b.Property<double>("AverageUserScore")
                        .HasColumnType("float")
                        .HasColumnName("average_user_score");

                    b.Property<string>("BannerUser")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("banner_user");

                    b.Property<string>("DescriptionUser")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("description_user");

                    b.Property<string>("FavoritePiece")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("favorite_piece");

                    b.Property<string>("HatedCharacter")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("hated_character");

                    b.Property<string>("LovelyCharacter")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("lovely_character");

                    b.Property<string>("TitleUser")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("title_user");

                    b.Property<string>("Username")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("username");

                    b.Property<string>("WorstPiece")
                        .HasMaxLength(80)
                        .HasColumnType("nvarchar(80)")
                        .HasColumnName("worst_piece");

                    b.HasKey("Id");

                    b.ToTable("Tbl_User");
                });

            modelBuilder.Entity("SodaPop.Models.Character", b =>
                {
                    b.HasOne("SodaPop.Models.Piece", "piece")
                        .WithMany("Characters")
                        .HasForeignKey("IdPiece")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("piece");
                });

            modelBuilder.Entity("SodaPop.Models.Piece", b =>
                {
                    b.Navigation("Characters");
                });
#pragma warning restore 612, 618
        }
    }
}
