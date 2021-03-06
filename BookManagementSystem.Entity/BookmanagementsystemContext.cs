// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BookManagementSystem.Entity
{
    public partial class BookmanagementsystemContext : DbContext
    {
        public BookmanagementsystemContext()
        {
        }

        public BookmanagementsystemContext(DbContextOptions<BookmanagementsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<admin_Login> admin_Login { get; set; }
        public virtual DbSet<author_Name> author_Name { get; set; }
        public virtual DbSet<book_Details> book_Details { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 //To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BookManagementSystem;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<admin_Login>(entity =>
            {
                entity.Property(e => e.Create_Time_Stamp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Update_Time_Stamp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Username).IsUnicode(false);

                entity.Property(e => e.password).IsUnicode(false);
            });

            modelBuilder.Entity<author_Name>(entity =>
            {
                entity.Property(e => e.Book_Author).IsUnicode(false);

                entity.Property(e => e.Create_Time_Stamp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Update_Time_Stamp).HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<book_Details>(entity =>
            {
                entity.Property(e => e.Book_Title).IsUnicode(false);

                entity.Property(e => e.Create_Time_Stamp).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Update_Time_Stamp).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Book_AuthorNavigation)
                    .WithMany(p => p.book_Details)
                    .HasForeignKey(d => d.Book_Author)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_book_Details_author_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}