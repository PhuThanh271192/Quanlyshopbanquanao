using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAo.Models.Entities;

namespace ShopQuanAo.Controllers
{
    public class HomeController : Controller
    {
        BanHang_Context db = new BanHang_Context();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult LoadDanhMuc()
        {
            List<DanhMuc> lstLoaiHang = db.DanhMucs.ToList();

            return PartialView("_Header",lstLoaiHang);
        }
        public ActionResult loadSanPham()
        {
            List<SanPham> lstSanPham = db.SanPhams.ToList();
            return PartialView("_Main",lstSanPham);
        }

       
    }
}