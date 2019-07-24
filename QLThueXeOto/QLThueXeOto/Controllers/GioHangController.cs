using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLThueXeOto.Models;

namespace QLThueXeOto.Controllers
{
    public class GioHangController : Controller
    {
        QuanLyThueXeOtoEntities db = new QuanLyThueXeOtoEntities();
        //Lay Gio Hang
        public List<GioHang> LayGioHang()
        {
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if(listGioHang == null)
            {
                //Nếu Giỏ Hàng chưa tồn tại thì tiến hành khởi tạo (SessionGioHang)
                listGioHang = new List<GioHang>();
                Session["GioHang"] = listGioHang;

            }
            return listGioHang;
        }
        //THêm giỏ hàng
        public ActionResult ThemGioHang(string iMaXe, string strURL)
        {
            Xe xe = db.Xes.SingleOrDefault(n => n.MaXe == iMaXe);
            if (xe == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            //Lấy ra session giỏ hàng
            List<GioHang> listGioHang = LayGioHang();
            //Kiem tra Xe này đã tồn tại trong session[giohang] chưa
            GioHang sanpham = listGioHang.Find(n => n.iMaXe == iMaXe);
            if (sanpham == null)
            {
                sanpham = new GioHang(iMaXe);
                //Add san pham moi them vao list
                listGioHang.Add(sanpham);
                return Redirect(strURL);
            }
            else
            {
                sanpham.iSoLuong++;
                return Redirect(strURL);
            }
        }
        //Cap Nhat Gio Hang
        public ActionResult CapNhatGioHang(string iMaSP,FormCollection f)
        {
            //Kiem tra masp
            Xe xe = db.Xes.SingleOrDefault(n => n.MaXe == iMaSP);
            if (xe == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> listGioHang = LayGioHang();
            GioHang sanpham = listGioHang.SingleOrDefault(n => n.iMaXe == iMaSP);
            if (sanpham != null)
            {
                sanpham.iSoLuong = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("GioHang");
        }
        //Xoa gio hang
        public ActionResult XoaGioHang(string iMaSP)
        {
            Xe xe = db.Xes.SingleOrDefault(n => n.MaXe == iMaSP);
            if (xe == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            List<GioHang> listGioHang = LayGioHang();
            GioHang sanpham = listGioHang.SingleOrDefault(n => n.iMaXe == iMaSP);
            if (sanpham != null)
            {
                listGioHang.RemoveAll(n => n.iMaXe == iMaSP);
                
            }
            if (listGioHang.Count == 0)
            {
                return RedirectToAction("Index","Home");
            }
            return RedirectToAction("GioHang");
        }
        //Xay dung trang gio hang
        public ActionResult GioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> listGioHang = LayGioHang();
            return View(listGioHang);
        }
        //Tinh tong so luong va tong tien
        private int TongSoLuong()
        {
            int iTongSoLuong = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                iTongSoLuong = listGioHang.Sum(n => n.iSoLuong);
            }
            return iTongSoLuong;
        }
        private double TongTien()
        {
            double dTongTien = 0;
            List<GioHang> listGioHang = Session["GioHang"] as List<GioHang>;
            if (listGioHang != null)
            {
                dTongTien = listGioHang.Sum(n => n.ThanhTien);
            }
            return dTongTien;
        }
        //Tao partial Gio Hang
        public ActionResult GioHangPartial()
        {
            if (TongSoLuong() == 0)
            {
                return PartialView();
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return PartialView();
        }
        //Nguoi DUng chinh sua gio hang
        public ActionResult SuaGioHang()
        {
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Home");
            }
            List<GioHang> listGioHang = LayGioHang();
            return View(listGioHang);
        }
    }
}