using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLThueXeOto.Models
{
    public class GioHang
    {
        //private string iMaXe;
        //public string IMaXe
        //{
        //    get { return iMaXe; }
        //    set { iMaXe = value; }
        //}
        QuanLyThueXeOtoEntities db = new QuanLyThueXeOtoEntities();
        public string iMaXe { get; set; }
        public string sTenXe { get; set; }
        public string sHinhAnh { get; set; }
        public int dDonGia { get; set; }
        public int iSoLuong { get; set; }
        public double ThanhTien {
            get { return iSoLuong * dDonGia; }
        }
        //Ham tao cho Gio Hang
        public GioHang(string MaXe) {
            iMaXe = MaXe;
            Xe Xe = db.Xes.Single(n => n.MaXe == iMaXe);
            sTenXe = Xe.BienSo;
            sHinhAnh = Xe.HinhAnh;
            //dDonGia = double.Parse(Xe.GiaThue.ToString());
            dDonGia = int.Parse(Xe.GiaThue.ToString());
            iSoLuong = 1;
        }
    }
}