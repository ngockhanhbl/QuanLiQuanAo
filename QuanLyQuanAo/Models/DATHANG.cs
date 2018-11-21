namespace QuanLyQuanAo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DATHANG")]
    public partial class DATHANG
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DATHANG()
        {
            DATHANGCHITIETs = new HashSet<DATHANGCHITIET>();
            HOADONs = new HashSet<HOADON>();
        }

        [StringLength(100)]
        public string DatHangID { get; set; }

        [StringLength(100)]
        public string TenKhachHang { get; set; }

        [StringLength(11)]
        public string SoDienThoai { get; set; }

        [StringLength(100)]
        public string MaDonHang { get; set; }

        [StringLength(100)]
        public string DiaChi { get; set; }

        [StringLength(100)]
        public string MaNhanVien { get; set; }

        public int? statusID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DATHANGCHITIET> DATHANGCHITIETs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HOADON> HOADONs { get; set; }
    }
}
