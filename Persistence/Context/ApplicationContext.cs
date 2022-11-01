using Microsoft.EntityFrameworkCore;
using socialNetwork.source.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace socialNetwork.source.Core.Persistence.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        //properties
        public DbSet<Coments> Coments { get; set; }
        public DbSet<Users> Users { get; set; }
        public DbSet<Friend> Friend { get; set; }
        public DbSet<Post> Post { get; set; }

        //on model creating
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            //fluent api name tables 
            #region tablesName
            modelBuilder.Entity<Coments>().ToTable("Coments");
            modelBuilder.Entity<Users>().ToTable("Users");
            modelBuilder.Entity<Friend>().ToTable("Friend");
            modelBuilder.Entity<Post>().ToTable("Post");
            #endregion

            //fluent api primary key
            #region primaryKey
            modelBuilder.Entity<Coments>().HasKey(c => c.id);
            modelBuilder.Entity<Users>().HasKey(c => c.id);
            modelBuilder.Entity<Coments>().HasKey(c => c.id);
            modelBuilder.Entity<Coments>().HasKey(c => c.id);
            #endregion

            //fluent api relationship
            #region reationship
            modelBuilder.Entity<Users>()
                .HasMany<Post>(u => u.post)
                .WithOne(p => p.PostUsers)
                .HasForeignKey(p => p.postUsersId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
                .HasMany<Coments>(p => p.ComentsPost)
                .WithOne(c => c.Post)
                .HasForeignKey(p => p.postComentID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Users>()
                .HasMany<Coments>(u => u.Coments)
                .WithOne(c => c.user)
                .HasForeignKey(p => p.userID)
                .OnDelete(DeleteBehavior.NoAction);
            #endregion

            //fluent api property configuration
            #region "property configuration"

            #region user
            modelBuilder.Entity<Users>().Property(u => u.Name)
                .IsRequired()
                .HasMaxLength(80);

            modelBuilder.Entity<Users>().Property(u => u.UserNickName)
                .IsRequired()
                .HasMaxLength(80);

            modelBuilder.Entity<Users>().Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(80);

            modelBuilder.Entity<Users>().Property(u => u.UserEmail)
                .IsRequired()
                .HasMaxLength(80);

            modelBuilder.Entity<Users>().Property(u => u.UserPassword)
                .IsRequired()
                .HasMaxLength(80);

            modelBuilder.Entity<Users>().Property(u => u.UserPhone)
                .IsRequired()
                .HasMaxLength(80);

            modelBuilder.Entity<Users>().Property(u => u.UserPhoto)
                .IsRequired();

            modelBuilder.Entity<Users>().Property(u => u.isActive)
               .IsRequired();

            #endregion

            #region post
            modelBuilder.Entity<Post>().Property(u => u.PostContent)
                .IsRequired()
                .HasMaxLength(80);

            modelBuilder.Entity<Post>().Property(u => u.PostImg)
                .IsRequired();
            #endregion

            #region Coments
            modelBuilder.Entity<Coments>().Property(u => u.Content)
                .IsRequired()
                .HasMaxLength(80);
            #endregion

            #region friend
            #endregion

            #endregion
        }
    }
}
