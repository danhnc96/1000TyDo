using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLThueXeOto.Models;

namespace QLThueXeOto.Controllers
{
    public class NguoiDungController : Controller
    {
        //
        // GET: /NguoiDung/
        QuanLyThueXeOtoEntities db = new QuanLyThueXeOtoEntities();
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult DangKy(Khach kh)
        {
            if(ModelState.IsValid){
                //Chen du lieu vao bang khach
                db.Khaches.Add(kh);
                //Luu vso csdl
                db.SaveChanges();
            }
            return View();
        }
        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DangNhap(FormCollection f)
        {
            string sTaiKhoan = f["txtTaiKhoan"].ToString();
            string sMatKhau = f.Get("txtMatKhau").ToString();
            Khach kh = db.Khaches.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);
            if (kh != null)
            {
                ViewBag.ThongBao = ("Xin Chào " + kh.TenKhach);
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng !";
            return View();
        }

	}
}