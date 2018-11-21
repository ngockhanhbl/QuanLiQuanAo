namespace QuanLyQuanAo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DATHANGCHITIET")]
    public partial class DATHANGCHITIET
    {
        [StringLength(100)]
        public string ID { get; set; }

        [StringLength(100)]
        public string DatHangID { get; set; }

        [StringLength(100)]
        public string MaHangHoa { get; set; }

        public int? SoLuong { get; set; }

        public virtual DATHANG DATHANG { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
