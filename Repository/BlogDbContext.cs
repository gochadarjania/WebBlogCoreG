using Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> option) : base(option)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Blog> Blogs { get; set; }
        public virtual DbSet<BlogComment> BlogComments { get; set; }
        public virtual DbSet<BlogHistory> BlogHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<User>().HasIndex(b => b.Mail).IsUnique();
            modelBuilder.Entity<Blog>().HasMany(b => b.Comments).WithOne(c => c.Blog).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<Blog>().HasMany(b => b.Histories).WithOne(h => h.Blog).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<User>().HasMany(u => u.Blogs).WithOne(b => b.User).OnDelete(DeleteBehavior.SetNull);
            modelBuilder.Entity<User>().HasMany(u => u.Comments).WithOne(c => c.User).OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<User>(b => { b.HasKey(u => u.ID); b.Property(u => u.ID).ValueGeneratedOnAdd(); }); 

            modelBuilder.Entity<Blog>(b => { b.HasKey(e => e.ID); b.Property(e => e.ID).ValueGeneratedOnAdd(); });

            // modelBuilder.Entity<Blog>().HasOne(b => b.User).WithMany(u => u.Blogs).OnDelete(DeleteBehavior.SetNull);

            //modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


        }
    }
}
