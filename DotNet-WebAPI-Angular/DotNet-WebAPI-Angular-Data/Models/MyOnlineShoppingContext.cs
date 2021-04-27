using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNet_WebAPI_Angular_Data.Models
{
    public partial class MyOnlineShoppingContext : DbContext
    {
        public MyOnlineShoppingContext(DbContextOptions<MyOnlineShoppingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartStatus> CartStatus { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<MemberRole> MemberRole { get; set; }
        public virtual DbSet<Members> Members { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<ShippingDetails> ShippingDetails { get; set; }
        public virtual DbSet<SlideImage> SlideImage { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-BT0HVIB\\SQLEXPRESS;Database=MyOnlineShopping;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_Product_ProductId");
            });

            modelBuilder.Entity<CartStatus>(entity =>
            {
                entity.Property(e => e.CartStatus1)
                    .HasColumnName("CartStatus")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.CategoryName)
                    .HasName("PK_Category_CategoryName")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MemberRole>(entity =>
            {
                entity.Property(e => e.MemberRoleId).HasColumnName("MemberRoleID");

                entity.Property(e => e.MemberId).HasColumnName("memberId");
            });

            modelBuilder.Entity<Members>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK_Members_MemberId");

                entity.HasIndex(e => e.EmailId)
                    .HasName("UQ_Members_EmailId")
                    .IsUnique();

                entity.HasIndex(e => e.LastName)
                    .HasName("UQ_Members_LastName")
                    .IsUnique();

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.FristName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.Password)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasIndex(e => e.ProductName)
                    .HasName("UQ_Product_ProductName")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductImage).IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Category_CategoryId");
            });

            modelBuilder.Entity<Roles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK_Roles_RoleId");

                entity.HasIndex(e => e.RoleName)
                    .HasName("UQ_Roles_RoleName")
                    .IsUnique();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ShippingDetails>(entity =>
            {
                entity.HasKey(e => e.ShippingDetailId)
                    .HasName("PK_ShippingDetails_ShippingDetailId");

                entity.Property(e => e.Adress)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.AmountPaid).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.City)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.State)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ZipCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.ShippingDetails)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK_Members_MemberId");
            });

            modelBuilder.Entity<SlideImage>(entity =>
            {
                entity.HasKey(e => e.SlideId)
                    .HasName("PK_SlideImage_SlideId");

                entity.Property(e => e.SlideImage1)
                    .HasColumnName("SlideImage")
                    .IsUnicode(false);

                entity.Property(e => e.SlideTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
