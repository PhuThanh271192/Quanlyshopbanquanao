namespace ShopQuanAo.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        public int MaTT { get; set; }

        [Required]
        [StringLength(100)]
        public string TenTT { get; set; }

        [StringLength(100)]
        public string Hinhanh { get; set; }

        public string Noidung { get; set; }
    }
}
