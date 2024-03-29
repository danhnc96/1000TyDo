﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace QLThueXeOto.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Khach
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Khach()
        {
            this.HopDongs = new HashSet<HopDong>();
        }
    
        public int MaKhach { get; set; }
        [Display(Name="Tên Khách Hàng")]//đổi tên cột có dấu
        [Required(ErrorMessage ="{0} Không được Để Trống")]
        public string TenKhach { get; set; }
        [Display(Name = "Địa Chỉ")]//đổi tên cột có dấu
        [Required(ErrorMessage = "{0} Không được Để Trống")]
        public string DiaChi { get; set; }
        public string CMTND { get; set; }
        [Display(Name = "Số Điện Thoại")]//đổi tên cột có dấu
        [Required(ErrorMessage = "{0} Không được Để Trống")]
        public string SoDT { get; set; }
        [Display(Name = "Số Tài Khoản Ngân Hàng")]//đổi tên cột có dấu
        [Required(ErrorMessage = "{0} Không được Để Trống")]
        public string SoTK { get; set; }
        [Display(Name = "Tên Ngân Hàng")]//đổi tên cột có dấu
        [Required(ErrorMessage = "{0} Không được Để Trống")]
        public string NganHang { get; set; }
        [Display(Name = "Tên Cơ Quan")]//đổi tên cột có dấu
        [Required(ErrorMessage = "{0} Không được Để Trống")]
        public string TenCQ { get; set; }
        [Display(Name = "Tên Đăng Nhập")]//đổi tên cột có dấu
        [Required(ErrorMessage = "{0} Không được Để Trống")]
        public string TaiKhoan { get; set; }
        [Display(Name = "Mật Khẩu")]//đổi tên cột có dấu
        [Required(ErrorMessage = "{0} Không được Để Trống")]
        public string MatKhau { get; set; }
        [Display(Name = "Email")]//đổi tên cột có dấu
        [Required(ErrorMessage = "{0} Không được Để Trống")]
        public string email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HopDong> HopDongs { get; set; }
    }
}
