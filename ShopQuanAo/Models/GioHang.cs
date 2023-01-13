using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShopQuanAo.Models.Entities;

namespace ShopQuanAo.Models
{
    public class CartItem
    {
        public SanPham sanPham { get; set; }
        public int soLuong { get; set; }
    }
    //Giỏ hàng
    public class Cart
    {
        List<CartItem> items = new List<CartItem>();
        //Lấy ra danh sách giỏ hàng
        public IEnumerable<CartItem> Items
        {
            get { return items; }
        }
        //Thêm sản phẩm vào giỏ hàng
        public  void AddCart(SanPham sp,int sl=1)
        {
            var item = items.FirstOrDefault(s => s.sanPham.MaSP == sp.MaSP);
            if (item == null)
            {
                items.Add(new CartItem
                {
                    sanPham = sp,
                    soLuong=sl
                });
            }
            else
            {
                item.soLuong += sl;
            }
        }
        public void UpdateSoLuong(int id, int soluong)
        {
            var item = items.Find(s => s.sanPham.MaSP == id);
            if (item != null)
            {
                item.soLuong = soluong;

            }
        }
        public double tongtien()
        {
            var sum = items.Sum(s => s.sanPham.GiaSP * s.soLuong);
            return (double)sum;
        }
        public void Remove(int id)
        {
            items.RemoveAll(s => s.sanPham.MaSP == id);

        }
        //trả về tông số lượng mua sắm
        public int sum_sl()
        {
            return items.Sum(s => s.soLuong);
        }
        public void ClearCart()
        {
            items.Clear();//Xóa giỏ hàng để hiển thị giỏ hàng mới
        }
    }

}
