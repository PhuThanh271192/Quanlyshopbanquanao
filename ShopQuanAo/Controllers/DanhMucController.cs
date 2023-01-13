using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAo.Models.Entities;

namespace ShopQuanAo.Controllers
{
    public class DanhMucController : Controller
    {
        BanHang_Context db = new BanHang_Context();
        // GET: DanhMuc
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult DanhMuc_SanPham(int idDM)
        {
            List<SanPham> lsthang = db.SanPhams.Where(h => h.MaDM == idDM).ToList();
            return PartialView(lsthang);
        }
        public ActionResult ChitietSP(int idSP)
        {
            var sp = db.SanPhams.Where(s => s.MaSP == idSP).FirstOrDefault();
            return PartialView(sp);
        }
        public ActionResult Shop_DanhMuc()
        {
            List<DanhMuc> lstDM = db.DanhMucs.ToList();
            return PartialView(lstDM);
        }
    }
}