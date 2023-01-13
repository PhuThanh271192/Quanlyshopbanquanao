namespace ShopQuanAo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("NguoiDung")]
    public partial class NguoiDung
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public NguoiDung()
        {
            DonHangs = new HashSet<DonHang>();
        }

        [Key]
        public int MaND { get; set; }
        [Required]

        [StringLength(100)]
        public string TenND { get; set; }
        [Required]

        [StringLength(100)]
        public string Email { get; set; }
        [Required]

        [StringLength(100)]
        public string DiaChi { get; set; }
        [Required]

        [StringLength(50)]
        public string MatKhau { get; set; }
        [Required]

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DonHang> DonHangs { get; set; }
    }
}
