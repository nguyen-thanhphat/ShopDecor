using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ShopAPI.Models
{
    public partial class ShopDBContext : DbContext
    {
        public ShopDBContext()
        {
        }

        public ShopDBContext(DbContextOptions<ShopDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Carts { get; set; } = null!;
        public virtual DbSet<CartItem> CartItems { get; set; } = null!;
        public virtual DbSet<Category> Categorys { get; set; } = null!;
        public virtual DbSet<Manager> Managers { get; set; } = null!;
        public virtual DbSet<Offer> Offers { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<Payment> Payments { get; set; } = null!;
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Review> Reviews { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasKey(e => e.IdCart)
                    .HasName("PK__Carts__3B7B33F2650CBDAD");

                entity.Property(e => e.Ordered).HasMaxLength(10);
            });

            modelBuilder.Entity<CartItem>(entity =>
            {
                entity.HasKey(e => e.IdCartItem)
                    .HasName("PK__CartItem__06D8E883BA156B82");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.IdCategory)
                    .HasName("PK__Category__CBD747064FBC2D85");

                entity.Property(e => e.CategoryName).HasMaxLength(50);

                entity.Property(e => e.SubCategory).HasMaxLength(50);
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.HasKey(e => e.IdAdmin)
                    .HasName("PK__Manager__4C3F97F497078D22");

                entity.ToTable("Manager");

                entity.Property(e => e.Password).HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Offer>(entity =>
            {
                entity.HasKey(e => e.IdOffer)
                    .HasName("PK__Offers__333FAA49306BC7B0");

                entity.Property(e => e.Title).HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.IdOrder)
                    .HasName("PK__Orders__C38F3009CCB95164");

                entity.HasOne(d => d.IdCartNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCart)
                    .HasConstraintName("FK__Orders__IdCart__4E88ABD4");

                entity.HasOne(d => d.IdCustommerNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdCustommer)
                    .HasConstraintName("FK__Orders__IdCustom__4CA06362");

                entity.HasOne(d => d.IdPaymentNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdPayment)
                    .HasConstraintName("FK__Orders__IdPaymen__4D94879B");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasKey(e => e.IdPayment)
                    .HasName("PK__Payments__613289C0213C10F0");

                entity.Property(e => e.CreateAt).HasMaxLength(200);

                entity.HasOne(d => d.IdPayMethodNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.IdPayMethod)
                    .HasConstraintName("FK__Payments__IdPayM__47DBAE45");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("FK__Payments__IdUser__46E78A0C");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.HasKey(e => e.IdPayMethod)
                    .HasName("PK__PaymentM__09128A42822623C1");

                entity.Property(e => e.PayProvider).HasMaxLength(200);

                entity.Property(e => e.PayReason).HasMaxLength(200);

                entity.Property(e => e.PayType).HasMaxLength(200);
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.HasKey(e => e.IdProduct)
                    .HasName("PK__Products__2E8946D42AF04C7C");

                entity.Property(e => e.Material).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ProductTile).HasMaxLength(250);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK__Products__IdCate__3C69FB99");

                entity.HasOne(d => d.IdOfferNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdOffer)
                    .HasConstraintName("FK__Products__IdOffe__3D5E1FD2");

                entity.HasOne(d => d.IdRoomNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdRoom)
                    .HasConstraintName("FK__Products__IdRoom__3E52440B");
            });

            modelBuilder.Entity<Review>(entity =>
            {
                entity.HasKey(e => e.IdReview)
                    .HasName("PK__Reviews__BB56047DEC361131");

                entity.Property(e => e.Review1).HasColumnName("Review");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("FK__Reviews__IdProdu__5441852A");

                entity.HasOne(d => d.IdReviewerNavigation)
                    .WithMany(p => p.Reviews)
                    .HasForeignKey(d => d.IdReviewer)
                    .HasConstraintName("FK__Reviews__IdRevie__534D60F1");
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.IdRoom)
                    .HasName("PK__Rooms__B436880F3FA701D2");

                entity.Property(e => e.RoomName).HasMaxLength(50);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser)
                    .HasName("PK__Users__B7C92638EB29E272");

                entity.Property(e => e.Address).HasMaxLength(100);

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.FistName).HasMaxLength(50);

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Mobile).HasMaxLength(10);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
