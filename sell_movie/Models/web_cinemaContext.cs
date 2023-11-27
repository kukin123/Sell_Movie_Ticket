using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace sell_movie.Models
{
    public partial class web_cinemaContext : DbContext
    {
        public web_cinemaContext()
        {
        }

        public web_cinemaContext(DbContextOptions<web_cinemaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Ctdatve> Ctdatves { get; set; } = null!;
        public virtual DbSet<Ghe> Ghes { get; set; } = null!;
        public virtual DbSet<Giave> Giaves { get; set; } = null!;
        public virtual DbSet<Khachhang> Khachhangs { get; set; } = null!;
        public virtual DbSet<Lichchieu> Lichchieus { get; set; } = null!;
        public virtual DbSet<Lichchieuphim> Lichchieuphims { get; set; } = null!;
        public virtual DbSet<Nguoidung> Nguoidungs { get; set; } = null!;
        public virtual DbSet<Nhanvien> Nhanviens { get; set; } = null!;
        public virtual DbSet<Phim> Phims { get; set; } = null!;
        public virtual DbSet<Phong> Phongs { get; set; } = null!;
        public virtual DbSet<Quocgium> Quocgia { get; set; } = null!;
        public virtual DbSet<Tdkhachhang> Tdkhachhangs { get; set; } = null!;
        public virtual DbSet<Thanhtoan> Thanhtoans { get; set; } = null!;
        public virtual DbSet<Theloai> Theloais { get; set; } = null!;
        public virtual DbSet<Trangthaighe> Trangthaighes { get; set; } = null!;
        public virtual DbSet<Ttdatve> Ttdatves { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-9DIIF9V;Initial Catalog=web_cinema;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ctdatve>(entity =>
            {
                entity.HasKey(e => e.MaDatVe)
                    .HasName("PK__ctdatve__6A32C5932284FFC6");

                entity.ToTable("ctdatve");

                entity.Property(e => e.MaDatVe).ValueGeneratedNever();

                entity.Property(e => e.MaGhe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaGheNavigation)
                    .WithMany(p => p.Ctdatves)
                    .HasForeignKey(d => d.MaGhe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ctdatve__MaGhe__45F365D3");
            });

            modelBuilder.Entity<Ghe>(entity =>
            {
                entity.HasKey(e => e.MaGhe)
                    .HasName("PK__ghe__2D87404C4FC393CB");

                entity.ToTable("ghe");

                entity.Property(e => e.MaGhe)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("maGhe");

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TenGhe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.Ghes)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ghe__MaPhong__4316F928");
            });

            modelBuilder.Entity<Giave>(entity =>
            {
                entity.HasKey(e => e.MaGiaVe)
                    .HasName("PK__giave__5A25399A86E7845F");

                entity.ToTable("giave");

                entity.Property(e => e.MaGiaVe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.GiaVe1).HasColumnName("GiaVe");

                entity.Property(e => e.TenLoaiVe)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Khachhang>(entity =>
            {
                entity.HasKey(e => e.Makhachhang)
                    .HasName("PK__khachhan__52F5E838E7187231");

                entity.ToTable("khachhang");

                entity.Property(e => e.Makhachhang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("makhachhang");

                entity.Property(e => e.Diachi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("diachi");

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Sdt)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("sdt");

                entity.Property(e => e.Tenkhachhang)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("tenkhachhang");
            });

            modelBuilder.Entity<Lichchieu>(entity =>
            {
                entity.HasKey(e => e.MaLichChieu)
                    .HasName("PK__lichchie__DC74019702A3E7D3");

                entity.ToTable("lichchieu");

                entity.Property(e => e.MaLichChieu)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NgayChieu).HasColumnType("date");
            });

            modelBuilder.Entity<Lichchieuphim>(entity =>
            {
                entity.HasKey(e => e.MaLichPhim)
                    .HasName("PK__lichchie__775BC2F5ED12DF89");

                entity.ToTable("lichchieuphim");

                entity.Property(e => e.MaLichPhim)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaLichChieu)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaPhim)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaLichChieuNavigation)
                    .WithMany(p => p.Lichchieuphims)
                    .HasForeignKey(d => d.MaLichChieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lichchieu__MaLic__5165187F");

                entity.HasOne(d => d.MaPhimNavigation)
                    .WithMany(p => p.Lichchieuphims)
                    .HasForeignKey(d => d.MaPhim)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lichchieu__MaPhi__534D60F1");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.Lichchieuphims)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__lichchieu__MaPho__52593CB8");
            });

            modelBuilder.Entity<Nguoidung>(entity =>
            {
                entity.HasKey(e => e.Username)
                    .HasName("PK__nguoidun__F3DBC5739B21BD05");

                entity.ToTable("nguoidung");

                entity.Property(e => e.Username)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("username");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("password");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.Nguoidungs)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__nguoidung__MaNha__5629CD9C");
            });

            modelBuilder.Entity<Nhanvien>(entity =>
            {
                entity.HasKey(e => e.MaNhanVien)
                    .HasName("PK__nhanvien__77B2CA47728F9C16");

                entity.ToTable("nhanvien");

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.DiaChi)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Gioitinh).HasColumnName("gioitinh");

                entity.Property(e => e.Ngaysinh)
                    .HasColumnType("date")
                    .HasColumnName("ngaysinh");

                entity.Property(e => e.SoDienThoai)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TenNhanVien)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Phim>(entity =>
            {
                entity.HasKey(e => e.MaPhim)
                    .HasName("PK__phim__4AC03DE3735349F1");

                entity.ToTable("phim");

                entity.Property(e => e.MaPhim)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Anh)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Banner)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("banner");

                entity.Property(e => e.MaQuocGia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaTl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MaTL");

                entity.Property(e => e.Mota).HasColumnType("text");

                entity.Property(e => e.Ngaykhoichieu)
                    .HasColumnType("date")
                    .HasColumnName("ngaykhoichieu");

                entity.Property(e => e.TenPhim)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Thoiluong).HasColumnName("thoiluong");

                entity.Property(e => e.Trailer)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaQuocGiaNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.MaQuocGia)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__phim__MaQuocGia__3E52440B");

                entity.HasOne(d => d.MaTlNavigation)
                    .WithMany(p => p.Phims)
                    .HasForeignKey(d => d.MaTl)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__phim__MaTL__3D5E1FD2");
            });

            modelBuilder.Entity<Phong>(entity =>
            {
                entity.HasKey(e => e.MaPhong)
                    .HasName("PK__phong__20BD5E5B0AD414B4");

                entity.ToTable("phong");

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Socot).HasColumnName("socot");

                entity.Property(e => e.TenPhong)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Quocgium>(entity =>
            {
                entity.HasKey(e => e.MaQuocgia)
                    .HasName("PK__quocgia__2B98FAF981106F0E");

                entity.ToTable("quocgia");

                entity.Property(e => e.MaQuocgia)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.TenQuocGia)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tdkhachhang>(entity =>
            {
                entity.HasKey(e => e.Makhachhang)
                    .HasName("PK__tdkhachh__52F5E8385846FB75");

                entity.ToTable("tdkhachhang");

                entity.Property(e => e.Makhachhang)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("makhachhang");

                entity.Property(e => e.HangKh)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("HangKH");

                entity.HasOne(d => d.MakhachhangNavigation)
                    .WithOne(p => p.Tdkhachhang)
                    .HasForeignKey<Tdkhachhang>(d => d.Makhachhang)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__tdkhachha__makha__4CA06362");
            });

            modelBuilder.Entity<Thanhtoan>(entity =>
            {
                entity.HasKey(e => e.MaThanhToan)
                    .HasName("PK__thanhtoa__D4B25844F11A733A");

                entity.ToTable("thanhtoan");

                entity.Property(e => e.MaThanhToan)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaNhanVien)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NgayThanhToan).HasColumnType("date");

                entity.Property(e => e.Phuongthucthanhtoan)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("phuongthucthanhtoan");

                entity.HasOne(d => d.MaDatVeNavigation)
                    .WithMany(p => p.Thanhtoans)
                    .HasForeignKey(d => d.MaDatVe)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__thanhtoan__MaDat__59063A47");

                entity.HasOne(d => d.MaNhanVienNavigation)
                    .WithMany(p => p.Thanhtoans)
                    .HasForeignKey(d => d.MaNhanVien)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__thanhtoan__MaNha__59FA5E80");
            });

            modelBuilder.Entity<Theloai>(entity =>
            {
                entity.HasKey(e => e.MaTl)
                    .HasName("PK__theloai__272500718149B989");

                entity.ToTable("theloai");

                entity.Property(e => e.MaTl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("MaTL");

                entity.Property(e => e.TenTl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("TenTL");
            });

            modelBuilder.Entity<Trangthaighe>(entity =>
            {
                entity.HasKey(e => e.Maghe)
                    .HasName("PK__trangtha__345578051DB4B8E5");

                entity.ToTable("trangthaighe");

                entity.Property(e => e.Maghe)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaLichChieu)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.MaPhong)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.MaLichChieuNavigation)
                    .WithMany(p => p.Trangthaighes)
                    .HasForeignKey(d => d.MaLichChieu)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trangthai__MaLic__5DCAEF64");

                entity.HasOne(d => d.MaPhongNavigation)
                    .WithMany(p => p.Trangthaighes)
                    .HasForeignKey(d => d.MaPhong)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__trangthai__MaPho__5CD6CB2B");
            });

            modelBuilder.Entity<Ttdatve>(entity =>
            {
                entity.HasKey(e => e.MaDatVe)
                    .HasName("PK__ttdatve__6A32C593376D4FAD");

                entity.ToTable("ttdatve");

                entity.Property(e => e.MaDatVe).ValueGeneratedNever();

                entity.Property(e => e.MaLichPhim)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.NgayDat).HasColumnType("date");

                entity.HasOne(d => d.MaLichPhimNavigation)
                    .WithMany(p => p.Ttdatves)
                    .HasForeignKey(d => d.MaLichPhim)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ttdatve__MaLichP__60A75C0F");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
