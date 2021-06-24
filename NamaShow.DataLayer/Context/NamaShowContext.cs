using Microsoft.EntityFrameworkCore;
using NamaShow.DataLayer.Entities;
using NamaShow.DataLayer.Entities.Categorie;
using NamaShow.DataLayer.Entities.Landing;
using NamaShow.DataLayer.Entities.Movie;
using NamaShow.DataLayer.Entities.Permision;
using System;
using System.Collections.Generic;
using System.Text;

namespace NamaShow.DataLayer.Context
{
  public class NamaShowContext:DbContext
    {
        public NamaShowContext(DbContextOptions op):base(op)
        {

        }

        public DbSet<User> Users{ get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieLink> MovieLinks { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<CommentLike> CommentLikes { get; set; }
        public DbSet<Link> Links { get; set; }
        public DbSet<Rate> Rates { get; set; }
        public DbSet<CatMovie> CatMovies { get; set; }
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Episode> Episodes { get; set; }

        public DbSet<Categorie> Categories { get; set; }

        public DbSet<Payment> Payments { get; set; }

        public DbSet<Permission> Permissions { get; set; }
        public DbSet<PermissionRole> permissionRoles { get; set; }


        public DbSet<Slide> Slides { get; set; }
        public DbSet<ComeingSoon> ComeingSoons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<User>()
                .HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Categorie>().
                HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Movie>().HasQueryFilter(u => !u.IsDelete);

            modelBuilder.Entity<Season>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Link>().HasQueryFilter(u => !u.IsDelete);
            modelBuilder.Entity<Episode>().HasQueryFilter(u => !u.IsDelete);
   
            base.OnModelCreating(modelBuilder);
        }
    }
}
