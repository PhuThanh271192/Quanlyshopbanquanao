namespace ShopQuanAo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            DonHangCTs = new HashSet<DonHangCT>();
        }

        [Key]
        public int MaSP { get; set; }

        [Required]
        [StringLength(100)]
        public string TenSP { get; set; }

        [StringLength(100)]
        public string Hinhanh { get; set; }

        public double? GiaSP { get; set; }

        [StringLength(50)]
        public string Mota { get; set; }

        public string GioiThieu { get; set; }

        public int? Soluong { get; set; }

        public bool? TinhTrang { get; set; }

        public double? DiemDanhGia { get; set; }

        public int? MaDM { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangCT> DonHangCTs { get; set; }
    }
}
