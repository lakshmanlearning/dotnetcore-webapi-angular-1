using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DotNet_WebAPI_Angular_Data.Models
{
    public partial class MyOnlineShoppingContext : DbContext
    {
        public MyOnlineShoppingContext()
        {
        }

        public MyOnlineShoppingContext(DbContextOptions<MyOnlineShoppingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCart> TblCart { get; set; }
        public virtual DbSet<TblCartStatus> TblCartStatus { get; set; }
        public virtual DbSet<TblCategory> TblCategory { get; set; }
        public virtual DbSet<TblMemberRole> TblMemberRole { get; set; }
        public virtual DbSet<TblMembers> TblMembers { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblRoles> TblRoles { get; set; }
        public virtual DbSet<TblShippingDetails> TblShippingDetails { get; set; }
        public virtual DbSet<TblSlideImage> TblSlideImage { get; set; }

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
            modelBuilder.Entity<TblCart>(entity =>
            {
                entity.HasKey(e => e.CartId)
                    .HasName("PK__Tbl_Cart__51BCD7B73F33F7E4");

                entity.ToTable("Tbl_Cart");

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TblCart)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK__Tbl_Cart__Produc__38996AB5");
            });

            modelBuilder.Entity<TblCartStatus>(entity =>
            {
                entity.HasKey(e => e.CartStatusId)
                    .HasName("PK__Tbl_Cart__031908A81CEDA288");

                entity.ToTable("Tbl_CartStatus");

                entity.Property(e => e.CartStatus)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId)
                    .HasName("PK__Tbl_Cate__19093A0BC69108BA");

                entity.ToTable("Tbl_Category");

                entity.HasIndex(e => e.CategoryName)
                    .HasName("UQ__Tbl_Cate__8517B2E043E760D6")
                    .IsUnique();

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblMemberRole>(entity =>
            {
                entity.HasKey(e => e.MemberRoleId)
                    .HasName("PK__Tbl_Memb__673C22CB01AB4D80");

                entity.ToTable("Tbl_MemberRole");

                entity.Property(e => e.MemberRoleId).HasColumnName("MemberRoleID");

                entity.Property(e => e.MemberId).HasColumnName("memberId");
            });

            modelBuilder.Entity<TblMembers>(entity =>
            {
                entity.HasKey(e => e.MemberId)
                    .HasName("PK__Tbl_Memb__0CF04B18415970A1");

                entity.ToTable("Tbl_Members");

                entity.HasIndex(e => e.EmailId)
                    .HasName("UQ__Tbl_Memb__7ED91ACEF8ED1434")
                    .IsUnique();

                entity.HasIndex(e => e.LastName)
                    .HasName("UQ__Tbl_Memb__7449F3991CF28E81")
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

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK__Tbl_Prod__B40CC6CD1825A255");

                entity.ToTable("Tbl_Product");

                entity.HasIndex(e => e.ProductName)
                    .HasName("UQ__Tbl_Prod__DD5A978A5803BACB")
                    .IsUnique();

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("datetime");

                entity.Property(e => e.ModifiedDate).HasColumnType("datetime");

                entity.Property(e => e.ProductImage).IsUnicode(false);

                entity.Property(e => e.ProductName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.TblProduct)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Tbl_Produ__Categ__398D8EEE");
            });

            modelBuilder.Entity<TblRoles>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__Tbl_Role__8AFACE1A7ED90F50");

                entity.ToTable("Tbl_Roles");

                entity.HasIndex(e => e.RoleName)
                    .HasName("UQ__Tbl_Role__8A2B616013064B8E")
                    .IsUnique();

                entity.Property(e => e.RoleName)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblShippingDetails>(entity =>
            {
                entity.HasKey(e => e.ShippingDetailId)
                    .HasName("PK__Tbl_Ship__FBB36851C936B996");

                entity.ToTable("Tbl_ShippingDetails");

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
                    .WithMany(p => p.TblShippingDetails)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("FK__Tbl_Shipp__Membe__3A81B327");
            });

            modelBuilder.Entity<TblSlideImage>(entity =>
            {
                entity.HasKey(e => e.SlideId)
                    .HasName("PK__Tbl_Slid__9E7CB650CE00DFD9");

                entity.ToTable("Tbl_SlideImage");

                entity.Property(e => e.SlideImage).IsUnicode(false);

                entity.Property(e => e.SlideTitle)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
