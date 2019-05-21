namespace BTL_TTNhom.EF
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("USERS")]
    public partial class USER
    {
        public long ID { get; set; }
        [Display(Name ="Tài khoản")]
        [Required(ErrorMessage ="{0} không dược để trống!!")]
        [StringLength(50)]
        public string UserName { get; set; }
        [Display(Name ="Mật khẩu")]
        [Required(ErrorMessage = "{0} không dược để trống!!")]
        [StringLength(32)]
        public string Password { get; set; }
        [Display(Name ="Họ tên")]
        [Required(ErrorMessage = "{0} không dược để trống!!")]
        [StringLength(50)]
        public string HoTen { get; set; }
        [Display(Name = "Địa chỉ")]
        [Required(ErrorMessage = "{0} không dược để trống!!")]
        [StringLength(50)]
        public string Diachi { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "{0} không dược để trống!!")]
        [StringLength(50)]
        public string Email { get; set; }
        [Display(Name = "Điện thoại")]
        [Required(ErrorMessage = "{0} không dược để trống!!")]
        [StringLength(50)]
        public string DienThoai { get; set; }

        public DateTime? NgayTao { get; set; }
        [Display(Name = "Người tạo")]
        [StringLength(50)]
        public string NguoiTao { get; set; }

        public DateTime? NgaySuaDoi { get; set; }
        [Display(Name = "Người sửa")]
        [StringLength(50)]
        public string NguoiSua { get; set; }
    }
}
