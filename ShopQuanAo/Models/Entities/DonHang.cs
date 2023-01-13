namespace ShopQuanAo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            DonHangCTs = new HashSet<DonHangCT>();
        }

        [Key]
        public int MaDH { get; set; }

        [Column(TypeName = "date")]
        public DateTime? NgayDatHang { get; set; }

        [StringLength(100)]
        public string DiaChiGH { get; set; }

        public bool? TinhTrang { get; set; }

        public int? MaTT { get; set; }

        public int? MaKH { get; set; }

        public virtual NguoiDung NguoiDung { get; set; }

        public virtual THanhToan THanhToan { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHangCT> DonHangCTs { get; set; }
    }
}
