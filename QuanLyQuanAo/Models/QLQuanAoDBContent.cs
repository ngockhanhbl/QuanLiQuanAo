namespace QuanLyQuanAo.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class QLQuanAoDBContent : DbContext
    {
        public QLQuanAoDBContent()
            : base("name=QLQuanAoDBContent")
        {
        }

        public virtual DbSet<account> accounts { get; set; }
        public virtual DbSet<CHITIETHOADON> CHITIETHOADONs { get; set; }
        public virtual DbSet<CHITIETSANPHAM> CHITIETSANPHAMs { get; set; }
        public virtual DbSet<DATHANG> DATHANGs { get; set; }
        public virtual DbSet<DATHANGCHITIET> DATHANGCHITIETs { get; set; }
        public virtual DbSet<HOADON> HOADONs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<NHANVIEN> NHANVIENs { get; set; }
        public virtual DbSet<nhapKho> nhapKhoes { get; set; }
        public virtual DbSet<QLHOADON> QLHOADONs { get; set; }
        public virtual DbSet<QLNHANVIEN> QLNHANVIENs { get; set; }
        public virtual DbSet<SANPHAM> SANPHAMs { get; set; }
        public virtual DbSet<TONKHO> TONKHOes { get; set; }
        public virtual DbSet<XUATKHO> XUATKHOes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<account>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .Property(e => e.position)
                .IsUnicode(false);

            modelBuilder.Entity<account>()
                .HasMany(e => e.NHANVIENs)
                .WithOptional(e => e.account)
                .HasForeignKey(e => e.tenDangNhap);

            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.BillID)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETHOADON>()
                .Property(e => e.ProductID)
                .IsUnicode(false);

            modelBuilder.Entity<CHITIETSANPHAM>()
                .Property(e => e.maSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.DatHangID)
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.TenKhachHang)
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.SoDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.MaDonHang)
                .IsUnicode(false);

            modelBuilder.Entity<DATHANG>()
                .Property(e => e.MaNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<DATHANGCHITIET>()
                .Property(e => e.ID)
                .IsUnicode(false);

            modelBuilder.Entity<DATHANGCHITIET>()
                .Property(e => e.DatHangID)
                .IsUnicode(false);

            modelBuilder.Entity<DATHANGCHITIET>()
                .Property(e => e.MaHangHoa)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.maHoaDon)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.maNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.DatHangID)
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .Property(e => e.SDTKhachHang)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<HOADON>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.HOADON)
                .HasForeignKey(e => e.BillID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<HOADON>()
                .HasOptional(e => e.QLHOADON)
                .WithRequired(e => e.HOADON);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.SDT)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .HasMany(e => e.HOADONs)
                .WithOptional(e => e.KHACHHANG)
                .HasForeignKey(e => e.SDTKhachHang);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.maNhanVien)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.cmnd)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.soDienThoai)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.tenDangNhap)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.diaChi)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .Property(e => e.chucVu)
                .IsUnicode(false);

            modelBuilder.Entity<NHANVIEN>()
                .HasOptional(e => e.QLNHANVIEN)
                .WithRequired(e => e.NHANVIEN);

            modelBuilder.Entity<nhapKho>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<nhapKho>()
                .Property(e => e.maSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<QLHOADON>()
                .Property(e => e.maHoaDon)
                .IsUnicode(false);

            modelBuilder.Entity<QLNHANVIEN>()
                .Property(e => e.chucVu)
                .IsUnicode(false);

            modelBuilder.Entity<QLNHANVIEN>()
                .Property(e => e.MaNV)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.maSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .Property(e => e.size)
                .IsUnicode(false);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.CHITIETHOADONs)
                .WithRequired(e => e.SANPHAM)
                .HasForeignKey(e => e.ProductID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SANPHAM>()
                .HasOptional(e => e.CHITIETSANPHAM)
                .WithRequired(e => e.SANPHAM);

            modelBuilder.Entity<SANPHAM>()
                .HasMany(e => e.DATHANGCHITIETs)
                .WithOptional(e => e.SANPHAM)
                .HasForeignKey(e => e.MaHangHoa);

            modelBuilder.Entity<SANPHAM>()
                .HasOptional(e => e.TONKHO)
                .WithRequired(e => e.SANPHAM);

            modelBuilder.Entity<TONKHO>()
                .Property(e => e.maSanPham)
                .IsUnicode(false);

            modelBuilder.Entity<XUATKHO>()
                .Property(e => e.id)
                .IsUnicode(false);

            modelBuilder.Entity<XUATKHO>()
                .Property(e => e.maSanPham)
                .IsUnicode(false);
        }
    }
}
