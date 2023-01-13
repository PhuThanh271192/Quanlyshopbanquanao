namespace ShopQuanAo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHangCT")]
    public partial class DonHangCT
    {
        [Key]
        public int MaCT { get; set; }

        public int? MaDH { get; set; }

        public int? MaSP { get; set; }

        public int? SoLuong { get; set; }

        public double? TongTien { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
