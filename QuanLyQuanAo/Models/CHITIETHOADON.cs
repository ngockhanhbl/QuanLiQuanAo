namespace QuanLyQuanAo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CHITIETHOADON")]
    public partial class CHITIETHOADON
    {
        [StringLength(100)]
        public string ID { get; set; }

        [Required]
        [StringLength(100)]
        public string BillID { get; set; }

        [Required]
        [StringLength(100)]
        public string ProductID { get; set; }

        public int Quantity { get; set; }

        public double Price { get; set; }

        public virtual HOADON HOADON { get; set; }

        public virtual SANPHAM SANPHAM { get; set; }
    }
}
