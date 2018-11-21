namespace QuanLyQuanAo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HOADON")]
    public partial class HOADON
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public HOADON()
        {
            CHITIETHOADONs = new HashSet<CHITIETHOADON>();
        }

        [Key]
        [StringLength(100)]
        public string maHoaDon { get; set; }

        [StringLength(100)]
        public string maNhanVien { get; set; }

        public DateTime ngayLapHoaDon { get; set; }

        [StringLength(100)]
        public string DatHangID { get; set; }

        public double? TongTien { get; set; }

        [StringLength(11)]
        public string SDTKhachHang { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CHITIETHOADON> CHITIETHOADONs { get; set; }

        public virtual DATHANG DATHANG { get; set; }

        public virtual KHACHHANG KHACHHANG { get; set; }

        public virtual NHANVIEN NHANVIEN { get; set; }

        public virtual QLHOADON QLHOADON { get; set; }
    }
}
