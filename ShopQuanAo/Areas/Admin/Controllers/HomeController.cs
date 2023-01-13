using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAo.Models.Entities;
using System.Data.Entity;

namespace ShopQuanAo.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        BanHang_Context db = new BanHang_Context();
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult QLDanhMuc()
        {
            List<DanhMuc> listDanhMuc = db.DanhMucs.ToList();
            return PartialView(listDanhMuc);

        }
        [HttpGet]
        public ActionResult Create()
        {
            DanhMuc danhMuc = new DanhMuc();
            return PartialView(danhMuc);
        }
        [HttpPost]
        public ActionResult Create(DanhMuc dm)
        {
            try
            {
                if (dm.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(dm.ImageUpload.FileName);
                    string extension = Path.GetExtension(dm.ImageUpload.FileName);
                    fileName = fileName + extension;
                    dm.AnhDM = fileName;
                    dm.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                    /* string plysicalPath = Server.MapPath("~/Content/images/product/" + fileName);
                     dm.ImageUpload.SaveAs(plysicalPath);*/
                }
                db.DanhMucs.Add(dm);
                db.SaveChanges();
                return RedirectToAction("QLDanhMuc");
            }
            catch (Exception)
            {
                return RedirectToAction("QLDanhMuc");
            }
        }
            
        public ActionResult Details(int id)
        {
            var chiTietDM = db.DanhMucs.Where(s => s.MaDM == id).FirstOrDefault();
            return PartialView(chiTietDM);
        }
        public ActionResult Delete(int id)
        {
            var idDM = db.DanhMucs.Where(s => s.MaDM == id).FirstOrDefault();
            return PartialView(idDM);
        }
        [HttpPost]
        public ActionResult Delete(int id,DanhMuc danhMuc)
        {
            try
            {
                danhMuc = db.DanhMucs.Where(s => s.MaDM == id).FirstOrDefault();
                db.DanhMucs.Remove(danhMuc);
                db.SaveChanges();
                return RedirectToAction("QLDanhMuc");
            }
            catch{

                return View();
            }
        }
        public ActionResult Edit(int id)
        {
            var idDM = db.DanhMucs.Where(s => s.MaDM == id).FirstOrDefault();
            return PartialView(idDM);
        }
        [HttpPost]
        public ActionResult Edit(int id,DanhMuc dm)
        {
            try
            {
                if (dm.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(dm.ImageUpload.FileName);
                    string extension = Path.GetExtension(dm.ImageUpload.FileName);
                    fileName = fileName + extension;
                    dm.AnhDM = fileName;
                    dm.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/product/"), fileName));
                    /* string plysicalPath = Server.MapPath("~/Content/images/product/" + fileName);
                     dm.ImageUpload.SaveAs(plysicalPath);*/
                }
                db.Entry(dm).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("QLDanhMuc");
            }
            catch
            {
                return View();
            }
        }


    }
}