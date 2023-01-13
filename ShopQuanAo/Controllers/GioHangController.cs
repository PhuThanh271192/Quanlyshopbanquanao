using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShopQuanAo.Models.Entities;
using ShopQuanAo.Models;

namespace ShopQuanAo.Controllers
{
    public class GioHangController : Controller
    {
        BanHang_Context db = new BanHang_Context();
        //Tạo giỏ hàng(gọi phương thức giỏ hàng)
        public Cart GetCart()
        {
            Cart cart = Session["Cart"] as Cart;
            if (cart == null || Session == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }
            return cart;
        }
        // Thêm sản phẩm vào giỏ hàng
       public ActionResult AddtoCart(int idSP)
        {
            var sp = db.SanPhams.SingleOrDefault(s => s.MaSP == idSP);
            if (sp != null)
            {
                GetCart().AddCart(sp);
            }
            return RedirectToAction("ShowCart", "GioHang");
        }
        //Load giỏ hàng
        public ActionResult ShowCart()
        {
            if (Session == null)
            {
                return RedirectToAction("ShowCart", "GioHang");
            }
            Cart cart = Session["Cart"] as Cart;
            return View(cart);
        }
        //update số lượng sản phẩm
        public ActionResult UPdateSL(FormCollection form)
        {
            Cart cart = Session["Cart"] as Cart;
            int idsp = int.Parse(form["id_sp"]);
            int sl = int.Parse(form["SoLuongsp"]);
            cart.UpdateSoLuong(idsp, sl);
            return RedirectToAction("ShowCart", "GioHang");
        }
        //Xóa sản phẩm
        public ActionResult RemoveCart(int id)
        {
            Cart cart = Session["Cart"] as Cart;
            cart.Remove(id);
            return RedirectToAction("ShowCart", "GioHang");

        }
        public PartialViewResult BagCart()
        {
            int total_item = 0;
            Cart cart = Session["cart"] as Cart;
            if (cart != null)
                total_item = cart.sum_sl();
            ViewBag.sl_item = total_item;
            return PartialView("BagCart");
        }
    }
}