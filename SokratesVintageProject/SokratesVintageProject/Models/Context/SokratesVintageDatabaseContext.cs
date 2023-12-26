using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SokratesVintageProject.Models.Entities;

namespace SokratesVintageProject.Models.Context
{
    public partial class SokratesVintageDatabaseContext : DbContext
    {
        public SokratesVintageDatabaseContext()
        {
        }

        public SokratesVintageDatabaseContext(DbContextOptions<SokratesVintageDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Adres> Adres { get; set; } = null!;
        public virtual DbSet<Kategori> Kategoris { get; set; } = null!;
        public virtual DbSet<Musteri> Musteris { get; set; } = null!;
        public virtual DbSet<Satis> Satis { get; set; } = null!;
        public virtual DbSet<Sepet> Sepets { get; set; } = null!;
        public virtual DbSet<Tasima> Tasimas { get; set; } = null!;
        public virtual DbSet<Urun> Uruns { get; set; } = null!;
        public virtual DbSet<UrunStok> UrunStoks { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=LAPTOP-IKUGTJSU\\SQLEXPRESS; Database=SokratesVintageDatabase; User Id=mnkrct; Password=12345");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Adres>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.MusteriApartman).HasMaxLength(30);

                entity.Property(e => e.MusteriCadde).HasMaxLength(30);

                entity.Property(e => e.MusteriIl).HasMaxLength(20);

                entity.Property(e => e.MusteriIlce).HasMaxLength(30);

                entity.Property(e => e.MusteriMahalle).HasMaxLength(30);

                entity.Property(e => e.MusteriSokak).HasMaxLength(30);

                entity.HasOne(d => d.MusteriNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Musteri)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adres_Tasima");

                entity.HasOne(d => d.Musteri1)
                    .WithMany()
                    .HasForeignKey(d => d.Musteri)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adres_Musteri");
            });

            modelBuilder.Entity<Kategori>(entity =>
            {
                entity.ToTable("Kategori");

                entity.Property(e => e.KategoriId).HasColumnName("KategoriID");

                entity.Property(e => e.KategoriAd).HasMaxLength(30);
            });

            modelBuilder.Entity<Musteri>(entity =>
            {
                entity.ToTable("Musteri");

                entity.Property(e => e.MusteriId).HasColumnName("MusteriID");

                entity.Property(e => e.MusteriAd).HasMaxLength(30);

                entity.Property(e => e.MusteriSoyad).HasMaxLength(20);
            });

            modelBuilder.Entity<Satis>(entity =>
            {
                entity.HasKey(e => e.SatisId);

                entity.Property(e => e.SatisId).HasColumnName("SatisID");

                entity.Property(e => e.Fiyat).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.MusteriNavigation)
                    .WithMany(p => p.Satis)
                    .HasForeignKey(d => d.Musteri)
                    .HasConstraintName("FK_Satis_Musteri");
            });

            modelBuilder.Entity<Sepet>(entity =>
            {
                entity.ToTable("Sepet");

                entity.Property(e=>e.UrunAd).HasMaxLength(50);

                entity.Property(e => e.UrunFiyat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UrunFotograf).HasMaxLength(100);

                entity.HasOne(d => d.MusteriNavigation)
                    .WithMany(p => p.Sepets)
                    .HasForeignKey(d => d.Musteri)
                    .HasConstraintName("FK_Sepet_Musteri");
            });

            modelBuilder.Entity<Tasima>(entity =>
            {
                entity.HasKey(e => e.Adres);

                entity.ToTable("Tasima");

                entity.Property(e => e.Adres).ValueGeneratedNever();

                entity.Property(e => e.KargoAd).HasMaxLength(20);

                entity.Property(e => e.KargoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("KargoID");

                entity.Property(e => e.TasimaUcret).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Kargo)
                    .WithMany(p => p.Tasimas)
                    .HasForeignKey(d => d.KargoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tasima_Satis");
            });

            modelBuilder.Entity<Urun>(entity =>
            {
                entity.ToTable("Urun");

                entity.Property(e => e.UrunId).HasColumnName("UrunID");

                entity.Property(e => e.UrunAd).HasMaxLength(50);

                entity.Property(e => e.UrunFiyat).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.UrunFotograf).HasMaxLength(100);

                entity.HasOne(d => d.SepetNavigation)
                    .WithMany(p => p.Uruns)
                    .HasForeignKey(d => d.Sepet)
                    .HasConstraintName("FK_Urun_Sepet");

                entity.HasOne(d => d.UrunKategoriNavigation)
                    .WithMany(p => p.Uruns)
                    .HasForeignKey(d => d.UrunKategori)
                    .HasConstraintName("FK_Urun_Kategori");
            });

            modelBuilder.Entity<UrunStok>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UrunStok");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
