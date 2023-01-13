using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ShopQuanAo.Models.Entities
{
    public partial class BanHang_Context : DbContext
    {
        public BanHang_Context()
            : base("name=BanHang_Context")
        {
        }

        public virtual DbSet<DanhMuc> DanhMucs { get; set; }
        public virtual DbSet<DonHang> DonHangs { get; set; }
        public virtual DbSet<DonHangCT> DonHangCTs { get; set; }
        public virtual DbSet<NguoiDung> NguoiDungs { get; set; }
        public virtual DbSet<SanPham> SanPhams { get; set; }
        public virtual DbSet<THanhToan> THanhToans { get; set; }
        public virtual DbSet<TinTuc> TinTucs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NguoiDung>()
                .HasMany(e => e.DonHangs)
                .WithOptional(e => e.NguoiDung)
                .HasForeignKey(e => e.MaKH);
        }
    }
}
