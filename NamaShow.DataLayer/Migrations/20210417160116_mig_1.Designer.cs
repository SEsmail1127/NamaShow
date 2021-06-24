﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NamaShow.DataLayer.Context;

namespace NamaShow.DataLayer.Migrations
{
    [DbContext(typeof(NamaShowContext))]
    [Migration("20210417160116_mig_1")]
    partial class mig_1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.4")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Categorie.Categorie", b =>
                {
                    b.Property<int>("CategorieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategorieId");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Landing.Slide", b =>
                {
                    b.Property<int>("SlideId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("Order")
                        .HasColumnType("tinyint");

                    b.Property<string>("Picture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SlideId");

                    b.ToTable("Slides");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.CatMovie", b =>
                {
                    b.Property<int>("CatMovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.HasKey("CatMovieId");

                    b.HasIndex("CategorieId");

                    b.HasIndex("MovieId");

                    b.ToTable("CatMovies");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Comment", b =>
                {
                    b.Property<int>("CommentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CommentText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Readed")
                        .HasColumnType("bit");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.HasKey("CommentId");

                    b.HasIndex("MovieId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.CommentLike", b =>
                {
                    b.Property<int>("CommentLikeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CommentId")
                        .HasColumnType("int");

                    b.Property<bool>("IsLike")
                        .HasColumnType("bit");

                    b.Property<string>("UserIP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CommentLikeId");

                    b.HasIndex("CommentId");

                    b.ToTable("CommentLikes");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Episode", b =>
                {
                    b.Property<int>("EpisodeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte>("EpisodeNumber")
                        .HasColumnType("tinyint");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PuttingUpDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("SeasonId")
                        .HasColumnType("int");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.HasKey("EpisodeId");

                    b.HasIndex("SeasonId");

                    b.ToTable("Episodes");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Link", b =>
                {
                    b.Property<int>("LinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("EpisodeId")
                        .HasColumnType("int");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LinkName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.HasKey("LinkId");

                    b.HasIndex("EpisodeId");

                    b.ToTable("Links");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Movie", b =>
                {
                    b.Property<int>("MovieId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Actors")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Describe")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Director")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<float?>("Imdb")
                        .HasColumnType("real");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("MoviePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MovieType")
                        .HasColumnType("int");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Trailer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("releaseTime")
                        .HasColumnType("datetime2");

                    b.HasKey("MovieId");

                    b.HasIndex("ParentId");

                    b.HasIndex("UserId");

                    b.ToTable("Movies");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.MovieLink", b =>
                {
                    b.Property<int>("MovieLinkId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("LinkName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<int?>("Price")
                        .HasColumnType("int");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.HasKey("MovieLinkId");

                    b.HasIndex("MovieId");

                    b.ToTable("MovieLinks");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Rate", b =>
                {
                    b.Property<int>("RateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Graid")
                        .HasColumnType("int");

                    b.Property<int>("MovieId")
                        .HasColumnType("int");

                    b.Property<string>("UserIP")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RateId");

                    b.HasIndex("MovieId");

                    b.ToTable("Rates");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Season", b =>
                {
                    b.Property<int>("SeasonId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int?>("MovieId")
                        .HasColumnType("int");

                    b.Property<byte>("SeasonNumber")
                        .HasColumnType("tinyint");

                    b.Property<bool>("Show")
                        .HasColumnType("bit");

                    b.HasKey("SeasonId");

                    b.HasIndex("MovieId");

                    b.ToTable("Seasons");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Payment", b =>
                {
                    b.Property<int>("PaymentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<bool>("IsPay")
                        .HasColumnType("bit");

                    b.Property<int>("LinkId")
                        .HasColumnType("int");

                    b.Property<DateTime>("PayDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("PaymentId");

                    b.HasIndex("Amount");

                    b.HasIndex("UserId");

                    b.ToTable("Payments");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Permision.Permission", b =>
                {
                    b.Property<int>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionRoleId")
                        .HasColumnType("int");

                    b.Property<string>("PermissionTitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("PermissionId");

                    b.HasIndex("ParentId");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Permision.PermissionRole", b =>
                {
                    b.Property<int>("PermissionRoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("PermissionRoleId");

                    b.HasIndex("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("permissionRoles");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Role", b =>
                {
                    b.Property<int>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActiveCode")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Family")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("UserPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.UserRole", b =>
                {
                    b.Property<int>("UR_Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("UR_Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Categorie.Categorie", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Categorie.Categorie", null)
                        .WithMany("ParentCategories")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.CatMovie", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Categorie.Categorie", "Categorie")
                        .WithMany("CatMovies")
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NamaShow.DataLayer.Entities.Movie.Movie", "Movie")
                        .WithMany("CatMovies")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Comment", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Movie.Movie", "Movie")
                        .WithMany("Comments")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.CommentLike", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Movie.Comment", "Comment")
                        .WithMany("CommentLikes")
                        .HasForeignKey("CommentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Comment");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Episode", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Movie.Season", "Season")
                        .WithMany("Episodes")
                        .HasForeignKey("SeasonId");

                    b.Navigation("Season");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Link", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Movie.Episode", "Episode")
                        .WithMany("Links")
                        .HasForeignKey("EpisodeId");

                    b.Navigation("Episode");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Movie", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Movie.Movie", null)
                        .WithMany("Movies")
                        .HasForeignKey("ParentId");

                    b.HasOne("NamaShow.DataLayer.Entities.User", "User")
                        .WithMany("Movies")
                        .HasForeignKey("UserId");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.MovieLink", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Movie.Movie", "Movie")
                        .WithMany("MovieLinks")
                        .HasForeignKey("MovieId");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Rate", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Movie.Movie", "Movie")
                        .WithMany("Rates")
                        .HasForeignKey("MovieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Season", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Movie.Movie", "Movie")
                        .WithMany("Seasons")
                        .HasForeignKey("MovieId");

                    b.Navigation("Movie");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Payment", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Movie.Link", "Link")
                        .WithMany()
                        .HasForeignKey("Amount")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NamaShow.DataLayer.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Link");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Permision.Permission", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Permision.Permission", null)
                        .WithMany("Permisions")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Permision.PermissionRole", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Permision.Permission", "Permission")
                        .WithMany("PermissionRoles")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NamaShow.DataLayer.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Permission");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.UserRole", b =>
                {
                    b.HasOne("NamaShow.DataLayer.Entities.Role", "Role")
                        .WithMany("UserRoles")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("NamaShow.DataLayer.Entities.User", "User")
                        .WithMany("UserRoles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("User");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Categorie.Categorie", b =>
                {
                    b.Navigation("CatMovies");

                    b.Navigation("ParentCategories");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Comment", b =>
                {
                    b.Navigation("CommentLikes");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Episode", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Movie", b =>
                {
                    b.Navigation("CatMovies");

                    b.Navigation("Comments");

                    b.Navigation("MovieLinks");

                    b.Navigation("Movies");

                    b.Navigation("Rates");

                    b.Navigation("Seasons");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Movie.Season", b =>
                {
                    b.Navigation("Episodes");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Permision.Permission", b =>
                {
                    b.Navigation("Permisions");

                    b.Navigation("PermissionRoles");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.Role", b =>
                {
                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("NamaShow.DataLayer.Entities.User", b =>
                {
                    b.Navigation("Movies");

                    b.Navigation("UserRoles");
                });
#pragma warning restore 612, 618
        }
    }
}
