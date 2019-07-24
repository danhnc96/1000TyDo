using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QLThueXeOto.Models;
using QLThueXeOto.Controllers;
using PagedList.Mvc;
using PagedList;


namespace QLThueXeOto.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        QuanLyThueXeOtoEntities db = new QuanLyThueXeOtoEntities();
        [HttpPost]
        public ActionResult KetQuaTimKiem(FormCollection f, int? page)
        {
            string sTuKhoa = f["txtTimKiem"].ToString();
            ViewBag.TuKhoa = sTuKhoa;
            List<Xe> lstKQTK = db.Xes.Where(n => n.MoTa.Contains(sTuKhoa)).ToList();
            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy ";
                return View(db.Xes.OrderBy(n => n.MoTa).ToPagedList(pageNumber, pageSize));
            }

            return View(db.Xes.OrderBy(n => n.MoTa).ToPagedList(pageNumber, pageSize));
        }
        [HttpGet]
        public ActionResult KetQuaTimKiem(string sTuKhoa, int? page)
        {
            ViewBag.TuKhoa = sTuKhoa;
            List<Xe> lstKQTK = db.Xes.Where(n => n.MoTa.Contains(sTuKhoa)).ToList();
            //Phan Trang
            int pageNumber = (page ?? 1);
            int pageSize = 9;
            if (lstKQTK.Count == 0)
            {
                ViewBag.ThongBao = "Không tìm thấy ";
                return View(db.Xes.OrderBy(n => n.MoTa).ToPagedList(pageNumber, pageSize));
            }
            return View(db.Xes.OrderBy(n => n.MoTa).ToPagedList(pageNumber, pageSize));
        }

    }
}